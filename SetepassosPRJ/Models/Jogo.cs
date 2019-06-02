using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo:IComparable   
    {
        #region Propriedades
        public int ID { get; set; }
        public string Utilizador { get; set; }
        public string Perfil { get; set; }
        public double PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public bool Chave { get; set; }
        public bool PosseChave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public int PocoesTotais { get; set; }
        public int MoedasOuro { get; set; }
        public int NumeroJogadas { get; set; } //propriedade acrescentada para contar quantas jogadas já foram efetuadas
        public double PontosVidaInimigo { get; set; }
        public int PontosSorteInimigo { get; set; }
        public int PontosAtaqueInimigo { get; set; }
        public bool Item { get; set; }
        public int Score { get; set; }
        public int NrInimigosVencidos { get; set; } 
        public int NrItensEncontrados { get; set; }
        public int NrAvancos { get; set; }
        public int NrRecuos { get; set; }
        public int NrFugasInimigo { get; set; }
        public int NrPassos { get; set; }
        public int NrAtaques { get; set; }
        public int NrPocoesUsadas { get; set; }
        public int NrExaminacoesArea { get; set; }
        public bool[] AreasExaminadas { get; set; } //Propriedade acrescentada para saber quais as áreas já examinadas
        public bool AreaExaminada { get; set; } //Propriedade acrescentada para saber se a área atual já foi examinada
        public bool Veneno { get; set; }
        public bool Arma { get; set; }
        public bool MiniPocao { get; set; }
        public bool Amuleto { get; set; }
        public RoundResult Resultado { get; set; } //Acrescentei esta propriedade para sabermos qual o resultado final
        public PlayerAction Acao { get; set; }
        #endregion

        #region Construtor
        public Jogo(string utilizador, string perfil)
        {
            Utilizador = utilizador;
            Perfil = perfil;

            if (perfil == "B")
            {
                PontosVida = 4;
                PontosAtaque = 3;
                PontosSorte = 2;
            }
            else if (perfil == "S")
            {
                PontosVida = 3;
                PontosAtaque = 3;
                PontosSorte = 3;
            }
            else
            {
                PontosVida = 3;
                PontosAtaque = 2;
                PontosSorte = 4;
            }

            PocoesVida = 1;
            PocoesTotais = PocoesVida;
            PosicaoHeroi = 0; //Temos que começar no 0 porque a GameApiResponse, por default, devolve a Action 0, i.e., a action GoForward
            DistanciaPorta = 7 - PosicaoHeroi;
            MoedasOuro = 0;
            NumeroJogadas = 0;
            AreasExaminadas = new bool[7];
        }
        #endregion
        
        #region Métodos
        //Método que atualiza o dados do jogo
        public void AtualizarJogo(GameApiResponse resposta)
        {
            ID = resposta.GameID;
            Item = resposta.FoundItem;
            MoedasOuro += resposta.GoldFound;
            Inimigo = resposta.FoundEnemy;
            PontosVidaInimigo = resposta.EnemyHealthPoints;
            PontosSorteInimigo = resposta.EnemyLuckPoints;
            PontosAtaqueInimigo = resposta.EnemyAttackPoints;
            ItemSurpresa(resposta);
            ChaveGuardada(resposta);
            NumeroJogadas = resposta.RoundNumber;
            AtualizarPosicao(resposta);
            InimigosVencidos(resposta);
            ItensEncontrados(resposta);
            Recuos(resposta);
            FugasInimigo(resposta);
            NrPassos += NrRecuos + NrAvancos + NrFugasInimigo;
            Ataques(resposta);
            ExaminarArea(resposta);
            Resultado = resposta.Result; //NOVO
            Acao = resposta.Action; //NOVO - de forma a que o botão Examinar Área não apareça numa posição em que já foi examinada
            AtualizarPontosVida(resposta);
            AtualizarPocoes(resposta);
            AtualizarPontosSorte(resposta);
            AtualizarPontosAtaque(resposta);
            AtualizarArrayAreasExaminadas(resposta); //NOVO
            AreaExaminada = AreasExaminadas[PosicaoHeroi - 1]; //NOVO
            Score = ScoreJogo(resposta);
        }

        //Atualiza o número de poções e os pontos de vida quando se bebe poções
        public void AtualizarPocoes(GameApiResponse resposta)
        {
            if (resposta.FoundPotion)
            {
                PocoesVida++;
                PocoesTotais++;
            }
            if (resposta.Action == PlayerAction.DrinkPotion && resposta.Result == RoundResult.Success)
            {
                PocoesVida--;
                NrPocoesUsadas++;

                if (Perfil == "B")
                {
                    PontosVida = 4;
                }
                else if (Perfil == "S")
                {
                    PontosVida = 3;
                }
                else
                {
                    PontosVida = 3;
                }
            }
        }

        //Atualiza os pontos de vida do herói
        public void AtualizarPontosVida(GameApiResponse resposta)
        {
            if (NrAtaques > 7 || NrPassos > 7 || NrExaminacoesArea > 7 || NrPocoesUsadas > 7)
            {
                PontosVida -= 0.5;
            }

            PontosVida -= resposta.EnemyDamageSuffered; //Dano causado pelo inimigo
            PontosVida += resposta.ItemHealthEffect; //Mini poção ou veneno

            if (PontosVida < 0)
            {
                PontosVida = 0;
            }
            else if(PontosVida > 5)
            {
                PontosVida = 5;
            }
        }

        //Atualiza os pontos de sorte do herói
        public void AtualizarPontosSorte(GameApiResponse resposta)
        {
            PontosSorte += resposta.ItemLuckEffect; // Amuleto
            if(PontosSorte > 5)
            {
                PontosSorte = 5;
            }
        }

        //Atualiza os pontos de ataque do herói
        public void AtualizarPontosAtaque(GameApiResponse resposta)
        {
            PontosAtaque += resposta.ItemAttackEffect; // Arma
            if(PontosAtaque > 5)
            {
                PontosAtaque = 5;
            }
        }

        //Método que atualiza a posição do herói
        public void AtualizarPosicao(GameApiResponse resposta)
        {
            if ((resposta.Action == PlayerAction.GoForward || resposta.Action == PlayerAction.Flee)
            && resposta.Result == RoundResult.Success && PosicaoHeroi <7)
            {
                PosicaoHeroi++;
            }
            else if (resposta.Action == PlayerAction.GoBack && resposta.Result == RoundResult.Success && PosicaoHeroi > 1)
            {
                PosicaoHeroi--;
            }
            DistanciaPorta = 7 - PosicaoHeroi;
        }

        //Conta quantos inimigos foram vencidos
        public void InimigosVencidos (GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.Attack && resposta.EnemyHealthPoints == 0)
                NrInimigosVencidos++;
        }

        //Conta quantos intens foram encontrados
        public void ItensEncontrados(GameApiResponse resposta)
        {
            if (resposta.FoundItem)
                NrItensEncontrados++;
        }

        public void ChaveGuardada(GameApiResponse resposta)
        {
            Chave = resposta.FoundKey; 
            if (Chave)
            {
                PosseChave = true;
            }
        }
        //Conta quantos vezes o herói avançou
        public void Avancos(GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.GoForward)
                NrAvancos++;
        }
        //Conta quantos vezes o herói recuou
        public void Recuos(GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.GoBack)
                NrRecuos++; 
        }

        //Conta quantas vezes o herói atacou
        public void Ataques(GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.Attack)
               NrAtaques++; 
        }

        //Calcula o número de fugas do inimigo
        public void FugasInimigo(GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.Flee && resposta.Result == RoundResult.Success)
            {
                NrFugasInimigo++;
            }
        }

        //Calcula o número de fugas do inimigo
        public void ExaminarArea(GameApiResponse resposta)
        {
            if (resposta.Action == PlayerAction.SearchArea && resposta.Result == RoundResult.Success)
            {
                NrExaminacoesArea++;
            }
        }

        //Atualiza para true cada elemento/casa se a área já foi examinada
        public void AtualizarArrayAreasExaminadas(GameApiResponse resposta)
        {
            if(resposta.Action == PlayerAction.SearchArea && resposta.Result == RoundResult.Success)
            {
                AreasExaminadas[PosicaoHeroi - 1] = true;
            }
        }

        //Calcula o Score do herói
        public int ScoreJogo(GameApiResponse resposta)
        {
            int moedas = MoedasOuro;
            if (resposta.Result == RoundResult.SuccessVictory)
            {
                moedas += 3000 + 1000;
                if (PontosVida < 0.5)
                {
                    moedas += 999;
                }
                if (NrRecuos == 0)
                {
                    moedas += 400;
                }
                if (NrAtaques == 0)
                {
                    moedas += 800;
                }
            }
            moedas += PocoesVida * 750;
            moedas += NrInimigosVencidos * 300;
            moedas += NrItensEncontrados * 100;
            return moedas;
        }

        //Método que retorna o item surpresa
        public void ItemSurpresa(GameApiResponse resposta)
        {
            if (resposta.ItemHealthEffect==-2)
            {
                Veneno = true;
                MiniPocao = false;
            }
            else if (resposta.ItemHealthEffect == 1)
            {
                MiniPocao = true;
                Veneno = false;
            }

            if (resposta.ItemAttackEffect==1)
            {
                Arma = true;
            }
            else
            {
                Arma = false;
            }

            if (resposta.ItemLuckEffect==2)
            {
                Amuleto = true;
            }
            else
            {
                Amuleto = false;
            }
        }
        #endregion

        #region CompareTo
        public int CompareTo(object obj)
        {
            Jogo j = (Jogo)obj;
            return Score.CompareTo(j.Score);
        }
        #endregion
    }
}

