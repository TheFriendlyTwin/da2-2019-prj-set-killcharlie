using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo
    {
        #region Lista Rondas
        private List<RoundSummary> rondas = new List<RoundSummary>();
        #endregion

        #region Propriedades
        public int ID { get; set; }
        public string Utilizador { get; set; }
        public string Perfil { get; set; }
        public double PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public int PocoesTotais { get; set; }
        public bool PocaoEncontrada { get; set; } //NOVO - Para avisar na view do jogo se encontrou poções
        public bool Chave { get; set; }
        public bool PosseChave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public int MoedasOuro { get; set; }
        public int NumeroJogadas { get; set; } //propriedade acrescentada para contar quantas jogadas já foram efetuadas
        public double PontosVidaInimigo { get; set; }
        public int PontosSorteInimigo { get; set; }
        public int PontosAtaqueInimigo { get; set; }
        public double DanoInimigo { get; set; } //NOVO - Para avisar na view do jogo quantos PV ganhou/perdeu 
        public bool Cansaco { get; set; } //NOVO - Para avisar na view do jogo quantos PV ganhou/perdeu 
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
        public double PercentagemInvestigacao { get; set; }
        public bool Veneno { get; set; }
        public bool Arma { get; set; }
        public bool MiniPocao { get; set; }
        public bool Amuleto { get; set; }
        public RoundResult Resultado { get; set; } //Acrescentei esta propriedade para sabermos qual o resultado final
        public PlayerAction Acao { get; set; }
        //PROPRIEDADE DA LISTA DE RONDAS
        public List<RoundSummary> Rondas
        {
            get
            {
                return rondas;
            }
        }
        #endregion

        #region Construtor
        public Jogo()
        {

        }
        
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
            PosicaoHeroi = 0; //Temos que começar no 0 pois a GameApiResponse, por default, devolve a Action 0 (GoForward)
            DistanciaPorta = 8 - PosicaoHeroi;
            MoedasOuro = 0;
            NumeroJogadas = 0;
            AreasExaminadas = new bool[7];
            NrAtaques = 0;
            NrInimigosVencidos = 0;
            NrItensEncontrados = 0;
            NrExaminacoesArea = 0;
            NrPocoesUsadas = 0;
            NrRecuos = 0;
            NrAvancos = 0;
            NrFugasInimigo = 0;
            NrPassos = 0;
            PercentagemInvestigacao = 0;
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
            DanoInimigo = resposta.EnemyDamageSuffered; 
            ItemSurpresa(resposta);
            ChaveGuardada(resposta);
            NumeroJogadas = resposta.RoundNumber;
            AtualizarPosicao(resposta);
            InimigosVencidos(resposta);
            ItensEncontrados(resposta);
            Avancos(resposta);
            Recuos(resposta);
            FugasInimigo(resposta);
            NrPassos = NrRecuos + NrAvancos + NrFugasInimigo;
            Ataques(resposta);
            ExaminarArea(resposta);
            Resultado = resposta.Result; 
            Acao = resposta.Action; 
            AtualizarPontosVida(resposta);
            AtualizarPocoes(resposta);
            AtualizarPontosSorte(resposta);
            AtualizarPontosAtaque(resposta);
            AtualizarArrayAreasExaminadas(resposta); //De forma a que o botão Examinar Área não apareça numa posição em que já foi examinada
            AreaExaminada = AreasExaminadas[PosicaoHeroi - 1];
            PercentagemInvestigacao = (NrExaminacoesArea * 100) / 7; //Calcula a percentagem de areas examinadas
        }

        //Atualiza o número de poções e os pontos de vida quando se bebe poções
        public void AtualizarPocoes(GameApiResponse resposta)
        {
            if (resposta.FoundPotion)
            {
                PocaoEncontrada = true;
                if(PocoesVida < 3)
                {
                    PocoesVida++;
                    PocoesTotais++;
                }
            }
            else
            {
                PocaoEncontrada = false;
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
            if ((NrAtaques > 7 || NrPassos > 7 || NrExaminacoesArea > 7 || NrPocoesUsadas > 7))
            {
                PontosVida -= 0.5;
                Cansaco = true;
            }

            //Caso o herói esteja na última área e na posse de chave, não lhe deve ser retirado os 0.5 PV
            if (PosicaoHeroi == 7 && PosseChave && Cansaco)
            {
                PontosVida += 0.5;
                Cansaco = false; //Para que na view não apareça -0.5 à frente dos PV
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
            DistanciaPorta = 8 - PosicaoHeroi;
        }

        //Indica se o herói está na posse da chave
        public void ChaveGuardada(GameApiResponse resposta)
        {
            Chave = resposta.FoundKey;
            if (Chave)
            {
                PosseChave = true;
            }
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

        //Calcula o número de examinações de área
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
        
        //Método que retorna o item surpresa
        public void ItemSurpresa(GameApiResponse resposta)
        {
            if (resposta.ItemHealthEffect == -2)
            {
                Veneno = true;
            }
            else
            {
                Veneno = false;
            }

            if (resposta.ItemHealthEffect == 1)
            {
                MiniPocao = true;
            }
            else
            {
                MiniPocao = false;
            }

            if (resposta.ItemAttackEffect == 1)
            {
                Arma = true;
            }
            else
            {
                Arma = false;
            }

            if (resposta.ItemLuckEffect == 2)
            {
                Amuleto = true;
            }
            else
            {
                Amuleto = false;
            }
        }
        
        //Calcula o Score do herói
        public void ScoreJogo()
        {
            Score += MoedasOuro;
            if (Resultado == RoundResult.SuccessVictory)
            {
                Score += 3000;
                if (PontosVida < 0.5)
                {
                    Score += 999;
                }
                if (NrRecuos == 0)
                {
                    Score += 400;
                }
                if (NrAtaques == 0)
                {
                    Score += 800;
                }
            }
            if (PosseChave == true)
            {
                Score += 1000;
            }
            Score += PocoesVida * 750;
            Score += NrInimigosVencidos * 300;
            Score += NrItensEncontrados * 100;
        }
        #endregion

        #region Modo Autónomo
        //Método que adiciona cada ronda à lista de rondas (do tipo Round Summary)
        public void AdicionarRonda(RoundSummary round)
        {
            Rondas.Add(round);
        }
        
        //Método que joga automaticamente
        public void AutoPlay(GameApiResponse resposta, int rondas)
        {
            Estrategia(resposta);
            RoundSummary nRonda = new RoundSummary(NumeroJogadas + 1, Acao, PosicaoHeroi, NrInimigosVencidos, NrFugasInimigo, NrItensEncontrados,
            PosseChave, MoedasOuro, PontosVida, PontosAtaque, PontosSorte, PocoesVida, Resultado);
            AdicionarRonda(nRonda);
        }

        //Estratégia para o jogo autónomo
        public void Estrategia(GameApiResponse resposta)
        {
            if (PontosVida < 1.2 && PocoesVida != 0)
            {
                resposta.Action = PlayerAction.DrinkPotion;
            }
            else
            {
                if (!PosseChave)
                {
                    if(NrPassos < 7)
                    {
                        if (!Inimigo)
                        {
                            if (!AreaExaminada)
                            {
                                resposta.Action = PlayerAction.SearchArea;
                            }
                            else
                            {
                                resposta.Action = PlayerAction.GoForward;
                            }
                        }
                        else
                        {
                            if(PontosVidaInimigo - PontosVida < 1)
                            {
                                resposta.Action = PlayerAction.Attack;
                            }
                            else
                            {
                                resposta.Action = PlayerAction.Flee;
                            }
                        }
                    }
                    else
                    {
                        if (!Inimigo)
                        {
                            if (!AreaExaminada)
                            {
                                resposta.Action = PlayerAction.SearchArea;
                            }
                            else
                            {
                                resposta.Action = PlayerAction.GoBack;
                            }
                        }
                        else
                        {
                            if (PontosVidaInimigo - PontosVida < 2)
                            {
                                resposta.Action = PlayerAction.Attack;
                            }
                            else
                            {
                                resposta.Action = PlayerAction.Flee;
                            }
                        }
                    }
                }
                else
                {
                    if (!Inimigo && !AreaExaminada)
                    {
                        resposta.Action = PlayerAction.SearchArea;
                    }
                    else if ((Inimigo && AreaExaminada) || (Inimigo && !AreaExaminada))
                    {
                        resposta.Action = PlayerAction.Attack;
                    }
                    else if (!Inimigo && AreaExaminada)
                    {
                        resposta.Action = PlayerAction.GoForward;
                    }
                }
            }
            Acao = resposta.Action; //Para atualizar o valor da propriedade Acao que é enviada como parâmetro no pedido (controller)
        }
        #endregion
    }
}

