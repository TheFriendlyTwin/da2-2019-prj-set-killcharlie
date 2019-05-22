using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class GameApiResponse
    {
        #region Propriedades
        public string PlayerName { get; set; }
        public string PlayerClass { get; set; }
        public string TeamKey { get; set; }
        public int GameID { get; set; }
        public int RoundNumber { get; set; }
        public int Action { get; set; }
        public int Result { get; set; }
        public bool FoundEnemy { get; set; }
        public bool FoundItem { get; set; }
        public bool FoundKey { get; set; }
        public bool FoundPotion { get; set; }
        public int GoldFound { get; set; }
        public double EnemyDamageSuffered { get; set; }
        public double EnemyHealthPoints { get; set; }
        public int EnemyAttackPoints { get; set; }
        public int EnemyLuckPoints { get; set; }
        public int ItemHealthEffect { get; set; }
        public int ItemAttackEffect { get; set; }
        public int ItemLuckEffect { get; set; }
        #endregion

        #region Enumeração
        public enum RoundResult { NoResult, Success, SuccessVictory, InvalidAction, GameHasEnded};
        #endregion

        #region Construtor
        public GameApiResponse(string playerName, string playerClass, string teamKey, int gameID, int roundNumber, int action, int result,
             bool foundEnemy, bool foundItem, bool foundKey, bool foundPotion, int goldFound, double enemyDamageSuffered,
             double enemyHealthPoints, int enemyAttackPoints, int enemyLuckPoints,
             int itemHealthEffect, int itemAttackEffect, int itemLuckEffect)
        {
            PlayerName = playerName;
            PlayerClass = playerClass;
            TeamKey = teamKey;
            GameID = gameID;
            RoundNumber = roundNumber;
            Action = action;
            Result = result;
            FoundEnemy = foundEnemy;
            FoundItem = foundItem;
            FoundKey = foundKey;
            FoundPotion = foundPotion;
            GoldFound = goldFound;
            EnemyDamageSuffered = enemyDamageSuffered;
            EnemyHealthPoints = enemyHealthPoints;
            EnemyAttackPoints = enemyAttackPoints;
            EnemyLuckPoints = enemyLuckPoints;
            ItemHealthEffect = itemHealthEffect;
            ItemAttackEffect = itemAttackEffect;
            ItemLuckEffect = itemLuckEffect;
        }
        #endregion
    }
}
