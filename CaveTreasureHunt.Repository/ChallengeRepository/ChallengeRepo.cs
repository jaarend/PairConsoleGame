using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.ChallengeEntities;
using CaveTreasureHunt.Data.Entities.EnemyEntities;
using CaveTreasureHunt.Repository.MonsterRepo;

namespace CaveTreasureHunt.Repository.ChallengeRepository
{
    public class ChallengeRepo
    {
                
        private readonly Monster _caveMonsterRepo =  new Monster();
        
        private readonly List<Challenge> _caveChallengeDb = new List<Challenge>();

        int _count = 0;

        public ChallengeRepo()
        {
            SeedChallenges();
        }

//* Create

        public bool AddChallenge(Challenge challenge)
        {
            if (challenge is null)
            {
                return false;
            }
            else
            {
                _count++;
                challenge.ID = _count;
                _caveChallengeDb.Add(challenge);
                return true;
            }
        }

//* Read all data in db

        public List<Challenge> GetChallenges()
        {
            return _caveChallengeDb;
        }
        public Challenge GetChallenge(int challengeID)
        {
            //* SQL LINK QUERY SYNTAX (optional) another way to do it
            // return (from challenge in _hHouseChallengeDb
            //         where challenge.ID == challengeID
            //         select challenge).FirstOrDefault()!;

            //* SQL LINK method Syntax another way to find using unique identifier
            // return _hHouseChallengeDb.FirstOrDefault(challenge => challenge.ID == challengeID)!;


            //* another way
            foreach (var challenge in _caveChallengeDb)
            {
                if(challenge.ID == challengeID)
                return challenge;
                else
                    return null!;
            }
            return null!;
        }

        private void SeedChallenges()
        {
            var room1 = new MonsterChallenge
            {
                ID = 1,
                ChallengeDescription = 
                "There are three Rooms\n"+
                "The left and right ones are unlocked\n"+
                "Find middle Room key\n"
                // ChallengeTasks = new List<string>
                // {
                //     "Find middle Room key\n"
                // }
            };

            var room2 = new MonsterChallenge
            {
                ID = 2,
                ChallengeDescription = 
                "Find the missing Puzzle Piece and put it back in its place.",
                // ChallengeTasks = new List<string>
                // {
                //     "Find the missing Puzzle Piece\n",
                //     "Put it back in its place\n"
                // }
            };

            // var room3 = new BossChallenge
            // {
            //     ID = 3,
            //     ChallengeDescription = 
            //     "Defeat the Demon with Pins in his Head!!",
            //     ChallengeTasks = new List<string>
            //     {
            //         "Defeat the Demon with Pins in his Head!!\n"
            //     }
            // };

            //add to db
            _caveChallengeDb.Add(room1);
            _caveChallengeDb.Add(room2);
            // _caveChallengeDb.Add(room3);
        }
    }
}