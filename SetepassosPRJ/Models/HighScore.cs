using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class HighScore : IComparable
    {
        #region Propriedades
        public string Nome { get; set; }
        public int Score { get; set; }
        public RoundResult ResultadoFinal { get; set; }
        public bool Chave { get; set; }
        public int InimigosVencidos { get; set; }
        public int FugasInimigos { get; set; }
        public int InvestigacoesArea { get; set; }
        public int IntensEcontrados { get; set; }
        public int PocoesUsadas { get; set; }
        public int PocoesTotal { get; set; }
        public int ID { get; set; }
        #endregion

        #region Construtor
        public HighScore()
        {

        }

        public HighScore(Jogo jogo)
        {
            Nome = jogo.Utilizador;
            Score = jogo.Score;
            ResultadoFinal = jogo.Resultado;
            Chave = jogo.PosseChave;
            InimigosVencidos = jogo.NrInimigosVencidos;
            FugasInimigos = jogo.NrFugasInimigo;
            InvestigacoesArea = jogo.NrExaminacoesArea;
            IntensEcontrados = jogo.NrItensEncontrados;
            PocoesUsadas = jogo.NrPocoesUsadas;
            PocoesTotal = jogo.PocoesTotais;
        }
        #endregion

        #region CompareTo
        public int CompareTo(object obj)
        {
            HighScore h = (HighScore)obj;
            return Score.CompareTo(h.Score);
        }
        #endregion
    }
}
