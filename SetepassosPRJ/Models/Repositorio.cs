using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SetepassosPRJ.Models
{
    public static class Repositorio
    {
        public static List<Jogo> jogos = new List<Jogo>();

        public static List<Jogo> Jogo
        {
           get
            {
            return jogos;
            }
         }

        public static void AdicionarJogo(Jogo novoJogo)
        {
            jogos.Add(novoJogo);
        }
    }
}
