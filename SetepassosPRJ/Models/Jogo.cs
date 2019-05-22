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
        public int PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosSorte { get; set; }
        public int PocoesVida { get; set; }
        public bool Chave { get; set; }
        public int PosicaoHeroi { get; set; }
        public int DistanciaPorta { get; set; } //propriedade acrescentada, que retorna os número de passos restantes para alcançar a porta
        public bool Inimigo { get; set; }
        public bool PocaoEncontrada { get; set; }
        public int MoedasOuro { get; set; }
        #endregion

        #region Construtor
        public Jogo(string utilizador, string perfil)
        {
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
            PosicaoHeroi = 1;
            DistanciaPorta = 7 - PosicaoHeroi;
            MoedasOuro = 0;
        }
        #endregion

        #region Métodos

        public void AtualizarJogo(GameApiResponse resposta, string utilizador, string perfil)
        {
            ID = resposta.GameID;

            if (resposta.FoundPotion)
            {
                PocoesVida++;
            }

            PocaoEncontrada = resposta.FoundPotion;
            MoedasOuro += resposta.GoldFound;
            Inimigo = resposta.FoundEnemy;
            Chave = resposta.FoundKey;
            Utilizador = utilizador;
            Perfil = perfil;
            
            if(resposta.Action == PlayerAction.GoForward)
            {
                PosicaoHeroi++;
            }
            else if(resposta.Action == PlayerAction.GoBack)
            {
                PosicaoHeroi--;
            }
        }
        
        #endregion
    }
}