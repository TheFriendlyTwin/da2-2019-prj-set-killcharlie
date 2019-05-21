﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetepassosPRJ.Models
{
    public class GameResponse
    {
        #region Propriedades
        public int GameID { get; set; }
        public int RoundNumber { get; set; }
        public int Action { get; set; }
        public int Result { get; set; }
        public bool FoundEnemy { get; set; }
        public bool FoundItem { get; set; }
        public bool FoundKey { get; set; }
        public bool FoundPotion { get; set; }
        public int GoldFound { get; set; }
        public int EnemyDamageSuffered { get; set; }
        public int EnemyHealthPoints { get; set; }
        public int EnemyAttackPoints { get; set; }
        public int EnemyLuckPoints { get; set; }
        public int ItemHealthEffect { get; set; }
        public int ItemAttackEffect { get; set; }
        public int ItemLuckEffect { get; set; }
        #endregion

        #region Construtor
        public GameResponse(int gameID, int roundNumber, int action, int result,
            bool foundEnemy, bool foundItem, bool foundKey, bool foundPotion, int goldFound, int enemyDamageSuffered,
            int enemyHealthPoints, int enemyAttackPoints, int enemyLuckPoints,
            int itemHealthEffect, int itemAttackEffect, int itemLuckEffect)
        {
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
