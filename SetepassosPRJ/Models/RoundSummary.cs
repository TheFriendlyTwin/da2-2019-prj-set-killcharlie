using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SetepassosPRJ.Models
{
    public class RoundSummary
    {
        public int NrRonda { get; set; }
        public PlayerAction DecisaoTomada {get;set;}
        public RoundResult ResultadoAcao { get; set; }
        public int PosicaoFinalRonda {get; set;}
        public int TotalAcumuladoInimigosVencidos { get; set; }
        public int TotalAcumuladoFugas { get; set; }
        public int TotalAcumuladoItensEncontrado { get; set; }
        public bool TerChave { get; set; }
        public int MoedasDeOuro { get; set; }
        public double PontosVidaFinais { get; set; }
        public int PontosAtaqueFinais { get; set; }
        public int PontosSorteFinais{ get; set; }
        public int PocoesVidaFinais { get; set; }

        public RoundSummary(int nRonda, PlayerAction acao, int posicaoFinalRonda, int inimigosVencidos, int fugas, int itensEncontrados, 
            bool chave, int ouro, double vidaFinal, int ataqueFinal, int sorteFinal, int pocoesFinal, RoundResult resultadoAcao)
        {
            NrRonda = nRonda;
            DecisaoTomada = acao;
            PosicaoFinalRonda = posicaoFinalRonda;
            TotalAcumuladoInimigosVencidos = inimigosVencidos;
            TotalAcumuladoFugas = fugas;
            TotalAcumuladoItensEncontrado = itensEncontrados;
            TerChave = chave;
            MoedasDeOuro = ouro;
            PontosVidaFinais = vidaFinal;
            PontosSorteFinais = sorteFinal;
            PontosAtaqueFinais = ataqueFinal;
            PocoesVidaFinais = pocoesFinal;
            ResultadoAcao = resultadoAcao;
        }
    
    }
}
