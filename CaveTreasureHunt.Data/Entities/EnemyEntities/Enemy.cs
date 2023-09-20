using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.PlayerEntities;

namespace CaveTreasureHunt.Data.Entities.EnemyEntities
{
    public abstract class Enemy
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HealthPoints { get; set; } = 100;

        public bool IsDead
        {
            get
            {
                return (HealthPoints <= 0) ? true : false;
            }
        }

        public void DecreasedHealth(int pointValue = 5)
        {
            if(HealthPoints >= 0)
            HealthPoints -= pointValue;
        }

        //todo: add Player
        public virtual void Attack(Player player, int attackPower, string attackName)
        {
            if(player.HealthPoints > 0)
            {
                player.DecreaseHealth(attackPower);
                System.Console.WriteLine($"{Name} just hit you with {attackName.ToUpper()} You lost {attackPower} health!");
            }
        }

    }
}