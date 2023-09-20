using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.CaveEntities;
using CaveTreasureHunt.Data.Entities.ChallengeEntities;
using CaveTreasureHunt.Repository.ChallengeRepository;

namespace CaveTreasureHunt.Repository.RoomRepository
{
    public class RoomRepo
    {
        // get list of challenges
        private readonly ChallengeRepo _roomChallengeRepo = new ChallengeRepo();

        //fake DB
        public List<Room> _roomDb = new List<Room>();
        int _count = 0;

        public RoomRepo()
        {
            SeedRoom();
        }

        //add
        public bool AddRoom(Room room)
        {

            if(room is null)
            {
                return false;
            }
            else
            {
                _count++;
                room.ID = _count;
                _roomDb.Add(room);
                return true;

            }

        }
        
        //get
        public List<Room> GetRooms()
        {
            return _roomDb;
        }
        public Room GetRoom(int id)
        {
            foreach (Room room in _roomDb)
            {
                if(room.ID == id)
                return room;
            }
            return null!;
        }

        //seed floors
        private void SeedRoom()
        {
            var room1 = new Room()
            {
                ID = 1,
                Name = "Room 1",
                Challenges = _roomChallengeRepo.GetChallenges().Where(c => c.GetType() == typeof(MonsterChallenge)).ToList()
            };
            var room2 = new Room()
            {
                ID = 2,
                Name = "Room 2",
                //todo: add Challenges
            };
            var room3 = new Room()
            {
                ID = 3,
                Name = "Room 3",
                //todo: add Challenges
            };
            // var room4 = new Room()
            // {
            //     ID = 4,
            //     Name = "Room 4",
            //     //todo: add Challenges
            // };
            // var room5 = new Room()
            // {
            //     ID = 5,
            //     Name = "Room 5",
            //     //todo: add Challenges
            // };

            _roomDb.Add(room1);
            _roomDb.Add(room2);
            _roomDb.Add(room3);
            // _roomDb.Add(room4);
            
        }
    }
}