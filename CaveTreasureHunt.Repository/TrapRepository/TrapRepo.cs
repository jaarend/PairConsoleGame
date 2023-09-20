using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.EnemyEntities;

namespace CaveTreasureHunt.Repository.TrapRepository
{
    public class TrapRepo
    {
        public List<Trap> _caveTrapDb = new List<Trap>();

        public int _count = 0;

        public TrapRepo()
        {
            SeedTrap();
        }

        private void AssignId(Trap trap)
        {
            _count++;
            trap.ID = _count;
        }

        private bool SaveToDatabase(Trap trap)
        {
            AssignId(trap);
            _caveTrapDb.Add(trap);
            return true;
        }

        public bool AddTrap(Trap trap)
        {
            return(trap is null) ? false:SaveToDatabase(trap);
        }

        public Trap GetTrap()
        {
            return _caveTrapDb.FirstOrDefault()!;
        }

        public Trap GetTrap(int id)
        {
            return _caveTrapDb.SingleOrDefault(x => x.ID == id)!;
        }

        private void SeedTrap()
        {
            var trap = new Trap
            {
                ID = 1,
                Name = "Spike Pit"
            };

            _caveTrapDb.Add(trap);

        }
    }
}