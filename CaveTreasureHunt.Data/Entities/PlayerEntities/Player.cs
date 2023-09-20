using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.EnemyEntities;
using CaveTreasureHunt.Data.Utilities;

namespace CaveTreasureHunt.Data.Entities.PlayerEntities
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            // SetUpPlayerInitialization();
            HealthPoints = 100;
        }
        public string Name {get; set;} = string.Empty;
        public int HealthPoints {get; set;}
        public bool IsDead
        {
            get
            {
                return (HealthPoints <= 0) ? true: false;
            }
        }
        // public List<InGameItem> Items;

        public void DecreaseHealth (int pointValue = 5)
        {
            if(HealthPoints >= 0)
            HealthPoints -=pointValue;
        }

      
    //   private void SetUpPlayerInitialization()
    // {
    //     Items = GameUtilities.InitializePlayerStartUpItems();
    //     Sword = Items[0];
    // }  

    // private InGameItem Sword;

public void SwingSword(Enemy enemy, int attackPower = 35)
   {
    System.Console.WriteLine($"You attacked {enemy.Name} with your sword");
    if (enemy.HealthPoints > 0)
    {
    enemy.DecreasedHealth(attackPower);
    }
   }

    }
}