using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo:IComparable
       
    {
        public int CompareTo(object obj)
        {
            Jogo j = (Jogo)obj;
            return Score.CompareTo(j.Score);
        }

        #region Propriedades
        public int ID { get; set; }
        public string Utilizador { get; set; }
        public string Perfil { get; set; }
        public double PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public bool Chave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public bool PocaoEncontrada { get; set; }
        public int MoedasOuro { get; set; }
        public int NumeroJogadas { get; set; } //propriedade acrescentada para contar quantas jogadas já foram efetuadas
        public double PontosVidaInimigo { get; set; }
        public int PontosSorteInimigo { get; set; }
        public int PontosAtaqueInimigo { get; set; }
        public bool Item { get; set; }
        public int Score { get; set; }
        public int NrInimigosVencidos { get; set; }
        public int NrItensEncontrados { get; set; }
        public int NrRecuos { get; set; }
        public int NrAtaques { get; set; }
        public int NrPocoesUsadas { get; set; }
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
            PosicaoHeroi = 0; //Temos que começar no 0 porque GameApiResponse, por default, devolve a Action 0, i.e., a action GoForward
            DistanciaPorta = 7 - PosicaoHeroi;
            MoedasOuro = 0;
            NumeroJogadas = 0;
        }
        #endregion

        
        #region Métodos
        //Método que atualiza o dados do jogo
        public void AtualizarJogo(GameApiResponse resposta)
        {
            ID = resposta.GameID;
            
            if (resposta.FoundPotion)
            {
                PocoesVida++;
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

            Item = resposta.FoundItem;

            if (resposta.RoundNumber > 7 && PontosVida > 0)
            {
                PontosVida -= 0.5;
            }
            if (PontosVida > 0 && PontosVida < 5)
            {
                PontosVida -= resposta.EnemyDamageSuffered; //Dano causado pelo inimigo
                PontosVida += resposta.ItemHealthEffect; //Mini poção ou veneno
            }
            if(PontosVida < 0)
            {
                PontosVida = 0;
            }
            
            PontosSorte += resposta.ItemLuckEffect; // Amuleto
            PontosAtaque += resposta.ItemAttackEffect; // Arma
            PocaoEncontrada = resposta.FoundPotion;
            MoedasOuro += resposta.GoldFound;
            Inimigo = resposta.FoundEnemy;
            PontosVidaInimigo = resposta.EnemyHealthPoints;
            PontosSorteInimigo = resposta.EnemyLuckPoints;
            PontosAtaqueInimigo = resposta.EnemyAttackPoints;
            Chave = resposta.FoundKey; //DUVIDA
            NumeroJogadas = resposta.RoundNumber;
            InimigosVencidos(resposta);
            ItensEncontrados(resposta);
            Recuos(resposta);
            Ataques(resposta);
            AtualizarPosicao(resposta);
            Score = ScoreJogo(resposta);
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
            if (resposta.Action == PlayerAction.Attack && resposta.Result == RoundResult.Success)
                NrInimigosVencidos++;
        }

        //Conta quantos intens foram encontrados
        public void ItensEncontrados(GameApiResponse resposta)
        {
            if (resposta.FoundItem)
                NrItensEncontrados++;
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

        //Calcula o Score do herói
        public int ScoreJogo(GameApiResponse resposta)
        
        {
            int moedas = MoedasOuro;
            if (resposta.Result == RoundResult.SuccessVictory)
            {
                moedas += 3000 + 1000;
            }
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

            moedas += PocoesVida * 750;
            moedas += NrInimigosVencidos * 300;
            moedas += NrItensEncontrados * 100;
            return moedas;
        }
        #endregion
    }
}

