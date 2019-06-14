using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SetepassosPRJ.Models
{
    public class RoundSummary
    {
        public int NrRondas { get; set; }
    //    public DecisaoTomada {get;set;}
    //public PosicaoFinalRonda {get; set;}
        public  string NomeMembroEquipa { get; set; }
      public int NrAlunoMembroEquipa { get; set; }
    public int TotalAcumuladoFugas { get; set; }
    public int TotalAcumuladoItensEncontrado { get; set; }
    public bool TerChave { get; set; }
    public int MoedasDeOuro { get; set; }
    public int TotalAcumuladoInimigosVencidos { get; set; }
    public int PocoesVidaFinais { get; set; }
    public int PontosVidaFinais { get; set; }
    public int PontosAtaqueFinais { get; set; }
    public int PontosSorteFinais{ get; set; }
    



}
}
