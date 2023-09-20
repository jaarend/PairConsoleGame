using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.CaveEntities;
using CaveTreasureHunt.Repository.RoomRepository;

namespace CaveTreasureHunt.Repository.CaveRepository
{
    public class CaveRepo
    {
        private readonly RoomRepo _caveRoomRepo = new RoomRepo();

        private List<Cave> _caveDb = new List<Cave>();
        int _count = 0;
        public CaveRepo()
        {
            SeedData();
        }

        public bool AddCave(Cave cave)
        {

            if(cave is null)
            {
                return false;
            }
            else
            {
                _count++;
                cave.ID = _count;
                _caveDb.Add(cave);
                return true;

            }

        }

        public Cave GetCave()
        {
            return _caveDb.FirstOrDefault()!;
        }

        //todo: HasCompletedGame method?

        private void SeedData()
        {
            var cave = new Cave();
            cave.RoomsInCave = _caveRoomRepo.GetRooms();
            AddCave(cave);
        }
    }
}