using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.ChallengeEntities;
using CaveTreasureHunt.Data.Entities.PlayerEntities;

namespace CaveTreasureHunt.Data.Entities.CaveEntities
{
    public class Cave
    {
        public Cave()
        {
            Name = "Black Bread's Cave";
            Location = "On the Island of Tortuga";
            Player = new Player("John");
            
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Player Player { get; set; }

        public List<Room> RoomsInCave = new List<Room>();


        public override string ToString()
        {
            
            var str =   $"ID: {ID}\n"+
                        $"Name: {Name}\n"+
                        $"Location: {Location}\n"+
                        "----- Rooms in Cave -----\n";
            foreach (Room room in RoomsInCave)
            {
                str+= $"RoomID: {room.ID}\n"+
                      $"Room Name: {room.Name}\n"+
                      "===== Room Challenges =====\n";
                // foreach (Challenge roomChallenge in room.Challenges)
                // {
                //     str += $"Room Challenge ID: {roomChallenge.ID}\n"+
                //            $"Room Challenge Description: {roomChallenge.ChallengeDescription}";
                //     foreach (string task in roomChallenge.ChallengeTasks)
                //     {
                //         str+=$"{task}";
                //     }
                //     str += $"Room Challenge Complete: {roomChallenge.IsComplete}";
                // }
            }
                      
            return str;
        }
    }
}