using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public class Jogo
    {
        #region Propriedades
        public int ID { get; set; }
        public string Utilizador { get; set; }
        public string Perfil { get; set; }
        public double PontosVida { get; set; }
        public double PontosAtaque { get; set; }
        public double PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public bool Chave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public bool PocaoEncontrada { get; set; }
        public int MoedasOuro { get; set; }
        public int NumeroJogadas { get; set; } //propriedade acrescentada para contar quantas jogadas já foram efetuadas
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
            NumeroJogadas = 7;
        }
        #endregion

        #region Métodos
        public void AtualizarJogo(GameApiResponse resposta)
        {
            ID = resposta.GameID;
            AtualizarPosicao(resposta);

            if (resposta.FoundPotion)
            {
                PocoesVida++;
            }
            if (resposta.Action == PlayerAction.DrinkPotion && resposta.Result == RoundResult.Success)
            {
                PocoesVida--;
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

            PontosVida -= resposta.EnemyDamageSuffered;
            PocaoEncontrada = resposta.FoundPotion;
            MoedasOuro += resposta.GoldFound;
            Inimigo = resposta.FoundEnemy;
            Chave = resposta.FoundKey;
            NumeroJogadas = 7 - resposta.RoundNumber;
        }

        public void AtualizarPosicao(GameApiResponse resposta)
        {
            if ((resposta.Action == PlayerAction.GoForward || resposta.Action == PlayerAction.Flee)
                && resposta.Result == RoundResult.Success)
            {
                PosicaoHeroi++;
            }
            else if (resposta.Action == PlayerAction.GoBack && resposta.Result == RoundResult.Success)
            {
                PosicaoHeroi--;
            }

            DistanciaPorta = 7 - PosicaoHeroi;
        }
        #endregion
    }
}

