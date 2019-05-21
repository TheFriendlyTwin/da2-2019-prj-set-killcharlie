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
        public static List<GameApiResponse> jogos = new List<GameApiResponse>();
        #endregion

        #region Propriedades
        public static List<GameApiResponse> Jogo
        {
           get
            {
            return jogos;
            }
         }
        #endregion

        #region Métodos
        //Adiciona o jogo à lista de jogos
        public static void AdicionarJogo(GameApiResponse novoJogo)
        {
            jogos.Add(novoJogo);
        }
        #endregion
    }
}
