using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class GameApiRequest
    {
        #region Propriedades
        [Required(ErrorMessage = "Por favor introduza um nome para o seu utilizador!")]
        public string PlayerName { get; set; }
        public string PlayerClass { get; set; }
        public string TeamKey { get; set; }
        #endregion

        #region Construtor
        public GameApiRequest(string playerName, string playerClass)
        {
            PlayerName = playerName;
            PlayerClass = playerClass;
            TeamKey = "757153521a8f474da578fd7ce77dfadc";
        }
        #endregion
    }
}












