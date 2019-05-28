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

        public static List<HighScore> scores = new List<HighScore>();
        #endregion

        #region Propriedades
        public static List<Jogo> Jogos
        {
            get
            {
                return jogos;
            }
        }

        public static List<HighScore> Scores
        {
            get
            {
                return scores;
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
            for(int i = 0; i < Jogos.Count; i++)
            {
                if(Jogos[i].ID == gameID)
                {
                    indice = i;
                }
            }
            return Jogos[indice];
        }

        public static void AdicionarScore(Jogo jogo)
        {
            HighScore score = new HighScore(jogo);
            scores.Add(score);
        }
        #endregion
    }
}
