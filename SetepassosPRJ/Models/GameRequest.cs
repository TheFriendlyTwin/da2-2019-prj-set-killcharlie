using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class GameRequest
    {
        #region Propriedades
        public string PlayerName { get; set; }
        public string PlayerClass { get; set; }
        public string TeamKey { get; set; }
        #endregion

        #region Construtor
        public GameRequest(string playerName, string playerClass, string teamKey)
        {
            PlayerName = playerName;
            PlayerClass = playerClass;
            TeamKey = teamKey;
        }
        #endregion
    }
}












