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
        private static List<Jogo> jogos = new List<Jogo>();

        private static List<TeamMember> teamMembers = new List<TeamMember>();
        #endregion

        #region Propriedades
        public static List<Jogo> Jogos
        {
            get
            {
                return jogos;
            }
        }

        //NOVA LISTA DE SCORES, DA QUAL VAMOS RETIRAR OS 10 MELHORES E METER NA LISTA DOS TOP 10 SCORES
        public static List<HighScore> Scores
        {
            get
            {
                SetePassosDbContext context = new SetePassosDbContext();
                List<HighScore> scores = context.Scores.ToList();
                return scores;
            }
        }

        //Nova lista para os teamMembers
        public static List<TeamMember> TeamMembers
        {
            get
            {
                TeamMember alexandra = new TeamMember("Alexandra", 160323018);
                TeamMember mafalda = new TeamMember("Mafalda", 170323021);
                TeamMember marta = new TeamMember("Marta", 170323021);

                teamMembers.Add(alexandra);
                teamMembers.Add(mafalda);
                teamMembers.Add(marta);
                return teamMembers;
            }  
        }

        

        #endregion

        #region Métodos
        //Adiciona o jogo à lista de jogos
        public static void AdicionarJogo(Jogo novoJogo)
        {
            Jogos.Add(novoJogo);
        }


        //Devolve o jogo dado um certo game id
        public static Jogo DevolverJogo(int gameID)
        {
            Jogo jogo = null;
            for (int i = 0; i < Jogos.Count; i++)
            {
                if (Jogos[i].ID == gameID)
                {
                    jogo = Jogos[i];
                }
            }
            return jogo;
        }

        //Adiciona os jogos terminados à lista de HighScores
        public static void AdicionarScore(Jogo jogo)
        {
            HighScore novoScore = new HighScore(jogo); //Transforma o jogo num objeto do tipo HighScore
            SetePassosDbContext context = new SetePassosDbContext();
            context.Scores.Add(novoScore); //Adiciona à Base de Dados o novo score 
            context.SaveChanges(); 
        }
    

        //Adiciona os 10 melhores elementos da lista de jogos na lista de scores
        public static List<HighScore> ListaScores(List<HighScore> scores)
        {
            List<HighScore> highScores = new List<HighScore>();
            for (int i = 0; i < scores.Count; i++)
            {
                if (highScores.Count < 10)
                {
                    HighScore score = scores[i];
                    highScores.Add(score);
                }
            }
            return highScores;
        }
        #endregion
    }
}
