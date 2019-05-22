using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public enum RoundResult { NoResult, Success, SuccessVictory, InvalidAction, GameHasEnded }
    public enum PlayerAction { GoForward, GoBack, SearchArea, DrinkPotion, Attack, Flee, Quit}

    public class PlayApiRequest
    {
        #region Propriedades
        public int Id { get; set; }
        public string Key { get; set; }
        public PlayerAction Playeraction { get; set; }
        #endregion
        
        #region Construtor
        public PlayApiRequest(int id, string key,PlayerAction playeraction)
        {
            Id = id;
            Key = "757153521a8f474da578fd7ce77dfadc";
            Playeraction = playeraction;
        }
        #endregion
    }
}
