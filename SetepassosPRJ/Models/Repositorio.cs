using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public static class Repositorio
    {
        #region Listas
        public static List<Jogo> jogos = new List<Jogo>();
        #endregion

        #region Propriedades
        public static List<Jogo> Jogo
        {
           get
            {
            return jogos;
            }
         }
        #endregion

        #region Métodos
        //Adiciona o jogo à lista de jogos
        public static void AdicionarJogo(Jogo novoJogo)
        {
            jogos.Add(novoJogo);
        }

        //Devolve o jogo dado um certo game id
        public static Jogo DevolverJogo(int gameID)
        {
            int indice = 0;
            for(int i = 0; i < Jogo.Count; i++)
            {
                if(Jogo[i].ID == gameID)
                {
                    indice = i;
                }
            }
            return Jogo[indice];
        }
        #endregion
    }
}
