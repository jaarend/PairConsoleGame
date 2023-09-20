using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.ChallengeEntities;

namespace CaveTreasureHunt.Data.Entities.CaveEntities
{
    public class Room
    {
        public int ID { get; set; }
        public string Name {get; set;} = string.Empty;
        public List<Challenge> Challenges {get; set;} = new List<Challenge>();
    }
}