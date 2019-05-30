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
        public static List<Jogo> Jogos
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
            for(int i = 0; i < Jogos.Count; i++)
            {
                if(Jogos[i].ID == gameID)
                {
                    indice = i;
                }
            }
            return Jogos[indice];
        }

        //Adiciona os 10 melhores elementos da lista de jogos na lista de scores
        public static List<HighScore> ListaScores(List<Jogo> jogos)
        {
            List<HighScore> scores = new List<HighScore>();
            for(int i = 0; i < jogos.Count; i++)
            {
                if (scores.Count < 10)
                {
                    HighScore score = new HighScore(jogos[i]);
                    scores.Add(score);
                }
                break;
            }
            return scores;
        }
        #endregion
    }
}
