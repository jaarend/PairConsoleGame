using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.EnemyEntities;

namespace CaveTreasureHunt.Data.Entities.ChallengeEntities
{
    public class TrapChallenge : Challenge
    {
        public Trap ? trap {get; set;} = new Trap();
    }
}