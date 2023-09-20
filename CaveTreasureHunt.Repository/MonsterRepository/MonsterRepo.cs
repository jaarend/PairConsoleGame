using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.EnemyEntities;

namespace CaveTreasureHunt.Repository.MonsterRepo
{
    public class MonsterRepo
    {
        //* need the fake database

        public List<Monster> _caveMonsterDb = new List<Monster>();
        public int _count = 0;

        public MonsterRepo()
        {  
           SeedMonster(); 
        }

        //helper methods for Create

        private void AssignId(Monster monster)
        {
            _count++;
            monster.ID = _count; //auto increament ids for monsters
        }

        private bool SaveToDatabase(Monster monster)
        {
            AssignId(monster);
            _caveMonsterDb.Add(monster);
            return true;
        }

        public bool AddMonster(Monster monster)
        {
            return(monster is null) ? false:SaveToDatabase(monster);
        }

        public Monster GetMonster()
        {
            return _caveMonsterDb.FirstOrDefault()!;
            
        }
        public Monster GetMonster(int id)
        {
            return _caveMonsterDb.SingleOrDefault(x => x.ID == id)!; 

        }

        private void SeedMonster()
        {
            var monster = new Monster
            {
                ID = 1, //will get overriden by AddBoss method
                Name = "Skelton"
            };

            _caveMonsterDb.Add(monster);
        }
    }
}