using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.EnemyEntities;

namespace CaveTreasureHunt.Data.Entities.ChallengeEntities
{
    public class MonsterChallenge : Challenge
    {
        public Monster ? monster {get; set;} = new Monster();
    }
}