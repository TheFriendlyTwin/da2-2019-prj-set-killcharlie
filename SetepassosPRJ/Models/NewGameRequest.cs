using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class NewGameRequest
    {
        public string PlayerName { get; set; }
        public string PlayerClass { get; set; }
        public string Teamkey { get; set; }

    
        public NewGameRequest(string playerName, string playerClass, string teamkey)
        {
        PlayerName = playerName;
        PlayerClass = playerClass;
        Teamkey = teamkey;
         }
    }
   
}












