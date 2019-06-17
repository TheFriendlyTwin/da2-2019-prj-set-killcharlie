using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class TeamMember
    {
        public string NomeEquipa { get; set; }
        public string NomeMembroEquipa { get; set; }
        public int NrAlunoMembroEquipa { get; set; }
        public int ID { get; set; }

        public TeamMember(string nome, int numero)
        {
            NomeEquipa = "KillCharlie";
            NomeMembroEquipa = nome;
            NrAlunoMembroEquipa = numero;
        }

        public TeamMember()
        {
                
        }
    }
}
