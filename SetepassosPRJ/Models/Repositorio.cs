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
        private static List<RoundSummary> rondas = new List<RoundSummary>();
        #endregion

        #region Propriedades
        public static List<Jogo> Jogos
        {
            get
            {
                return jogos;
            }
        }

        public static List<RoundSummary> Rondas
        {
            get
            {
                return rondas;
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
        public static List<TeamMember> Members
        {
            get
            {
                SetePassosDbContext context = new SetePassosDbContext();
                List<TeamMember> members = context.Members.ToList();
                return members;
            }  
        }
        #endregion

        #region Métodos
          
        public static void AdicionarRonda(RoundSummary round)
        {
            rondas.Add(round);

        }



        public static void AdicionarMembro()
        {
            TeamMember alexandra = new TeamMember("Alexandra", 160323018);
            TeamMember mafalda = new TeamMember("Mafalda", 170323021);
            TeamMember marta = new TeamMember("Marta", 170323021);

            SetePassosDbContext context = new SetePassosDbContext();

            context.Members.Add(alexandra);
            context.Members.Add(mafalda);
            context.Members.Add(marta);
        }


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
                if (highScores.Count==10)
                {
                    break;
                }
            }
            return highScores;
        }

        //Lista com n scores do jogador pedido
        public static List<HighScore> TopScoreJogador(ScoreJogador jogador)
        {
            List<HighScore> scoresJogador = new List<HighScore>();
            List<HighScore> rankings = Scores; //Lista scores da base de dados
            rankings.Sort();
            rankings.Reverse();
            foreach(HighScore pontuacao in rankings)
            {
                if (scoresJogador.Count < jogador.numeroResultados)
                {
                    if (jogador.nomeJogador =="")
                    {
                        scoresJogador.Add(pontuacao);
                    }
                    else if( pontuacao.Nome == jogador.nomeJogador)
                    {
                        scoresJogador.Add(pontuacao);
                    }
                }
                if (scoresJogador.Count==jogador.numeroResultados)
                {
                    break;
                }
            }
            return scoresJogador;
        }
        #endregion
    }
}
