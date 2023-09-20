using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.CaveEntities;
using CaveTreasureHunt.Data.Entities.ChallengeEntities;
using CaveTreasureHunt.Data.Entities.PlayerEntities;

namespace CaveTreasureHunt.Data.Utilities
{
    public static class GameUtilities
    {
         public static void TellTheStory(string storySection)
        {
            System.Console.WriteLine(storySection);
        }
        // public static List<InGameItem> InitializePlayerStartUpItems()
        // {
        //     List<InGameItem> playerStartingItems = new List<InGameItem>();
        //     return playerStartingItems;

        // }

        public static void DisplayCaveChallengeInfo(Cave _cave)
        {
            foreach (Room room in _cave.RoomsInCave)
            {
                foreach(Challenge Challenge in room.Challenges)
                {
                    System.Console.WriteLine(Challenge.ChallengeDescription);
                }
            }
        }
    }
}