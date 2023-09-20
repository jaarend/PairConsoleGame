using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.CaveEntities;

namespace CaveTreasureHunt.Repository.LevelRepository
{
    public class LevelRepo
    {
        // get list of challenges
        // private readonly ChallengeRepo _levelChallengeRepo = new ChallengeRepo(); //todo: add ChallengeRepo

        //fake DB
        public List<Level> _levelDb = new List<Level>();
        int _count = 0;

        public LevelRepo()
        {
            SeedLevel();
        }

        //add
        public bool AddLevel(Level level)
        {

            if(level is null)
            {
                return false;
            }
            else
            {
                _count++;
                level.ID = _count;
                _levelDb.Add(level);
                return true;

            }

        }
        

        //get
        public List<Level> GetLevels()
        {
            return _levelDb;
        }
        public Level GetLevel(int id)
        {
            foreach (Level level in _levelDb)
            {
                if(level.ID == id)
                return level;
            }
            return null!;
        }

        //seed floors
        private void SeedLevel()
        {
            var level0 = new Level()
            {
                ID = 0,
                Name = "Cave Entrance",
                //todo: add Challenges
            };
            var level1 = new Level()
            {
                ID = 1,
                Name = "Level 1",
                //todo: add Challenges
            };
            var level2 = new Level()
            {
                ID = 2,
                Name = "Level 2",
                //todo: add Challenges
            };
            var level3 = new Level()
            {
                ID = 3,
                Name = "Level 3",
                //todo: add Challenges
            };
            var level4 = new Level()
            {
                ID = 4,
                Name = "Level 4",
                //todo: add Challenges
            };

            _levelDb.Add(level0);
            _levelDb.Add(level1);
            _levelDb.Add(level2);
            _levelDb.Add(level3);
            _levelDb.Add(level4);
        }
    }
}