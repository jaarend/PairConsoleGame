using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveTreasureHunt.Data.Entities.CaveEntities;
using CaveTreasureHunt.Data.Entities.EnemyEntities;
using CaveTreasureHunt.Data.Entities.Enums;
using CaveTreasureHunt.Data.Utilities;
using CaveTreasureHunt.Repository.CaveRepository;
using CaveTreasureHunt.Repository.MonsterRepo;
using CaveTreasureHunt.Repository.TrapRepository;
using static System.Console;

namespace CaveTreasureHunt.UI
{
    public class ProgramUI
    {

        private readonly CaveRepo _caveRepo = new CaveRepo();
        private readonly MonsterRepo _monsterRepo = new MonsterRepo();
        private readonly TrapRepo _trapRepo = new TrapRepo();
        private Cave _cave;
        private Monster _monster;
        private bool IsRunning = true;
        public bool _hasTreasureKey;

        public ProgramUI()
        {
            _cave = _caveRepo.GetCave();
            _monster = _monsterRepo.GetMonster();
        }

        public void Run()
        {
            RunApplication();
        }

        private void GetKeyFalse()
        {
            _hasTreasureKey = false;
        }

        private void GetKeyTrue()
        {
            _hasTreasureKey = true;
        }

        private void RunApplication()
        {

            bool IsRunning = true;
            while (IsRunning && _cave.Player.IsDead == false) //infinite loop running the game
            {
                Clear();

                System.Console.WriteLine("+++++++++++++++++++++++++++++ \n" +
                                         "+    CAVE TREASURE HUNT     + \n" +
                                         "+++++++++++++++++++++++++++++ \n" +

                                        "1. Start Game\n" +
                                        "2. Exit App\n");
                string userInput = ReadLine()!;

                switch (userInput)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        IsRunning = ExitApplication();
                        break;
                    default:
                        WriteLine("Invalid Selection.");
                        break;
                }
            }
        }



        private void StartGame()
        {
            Clear();
            GetKeyFalse();
            while (!_cave.Player.IsDead && IsRunning)
            {
                Clear();
                GameUtilities.TellTheStory( "+++++++++++++++++++++++++++++ \n" +
                                            "+           START           + \n" +
                                            "+++++++++++++++++++++++++++++ \n" +

                                            $"You name is {_cave.Player.Name}, a famous Treasure Hunter. \nYou've heard from the locals that there is a cave called {_cave.Name} on the {_cave.Location}\n" +
                                            $"... Press any Key to Continue...\n");

                ReadKey();
                Clear();

                LoadIntro();

                ReadKey();
            }
            // if (_cave.Player.IsDead)
            // {
            //     IsRunning = ExitApplication();
            // }

        }

        private void LoadIntro()
        {
            Clear();
            GameUtilities.TellTheStory("You enter the cave and see three different tunnels. \nOne to your right, straight head and one on the left.\n");

            GameUtilities.TellTheStory("Which tunnel would you like to enter?\n" +
                                        "1. Left\n" +
                                        "2. Straight \n" +
                                        "3. Right \n");

            string userInput = ReadLine()!;

            switch (userInput)
            {
                case "1":
                    LoadChallenge1();
                    break;
                case "2":
                    LoadChallenge2();
                    break;
                case "3":
                    LoadChallenge3();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }

        private void LoadChallenge3()
        {
            Clear();

            GameUtilities.TellTheStory("ROOM 3: You find a nice crystal clear pool in the middle of the room. On the otherside is the only exit tunnel. \n" + "You take it.\n" +
                                        "Press any key to continue.");

            ReadKey();
            LoadChallenge7();
        }

        private void LoadChallenge7()
        {
            Clear();

            GameUtilities.TellTheStory("ROOM 7: You enter the room and see two different tunnels. \n One to your right, and one on the left.\n");

            GameUtilities.TellTheStory("Which tunnel would you like to enter?\n" +
                                        "1. Left\n" +
                                        "2. Right \n");

            string userInput = ReadLine()!;

            switch (userInput)
            {
                case "1":
                    LoadChallenge8();
                    break;
                case "2":
                    LoadChallenge9();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }

            ReadKey();
        }

        private void LoadChallenge9()
        {

            Clear();

            GameUtilities.TellTheStory($"ROOM 9: You get ambused by a HUGE {_monster.Name} !!\n");
            _monster.AttackPlayer();
            _cave.Player.DecreaseHealth(30);

            GameUtilities.TellTheStory($"Fight {_monster.Name} !!\n" + "Press Key to Swing your Sword!");

            ReadKey();

            _cave.Player.SwingSword(_monster, 100);

            GameUtilities.TellTheStory($"You have {_cave.Player.HealthPoints} health left.");

            if (_cave.Player.HealthPoints <= 0)
            {
                IsDead();
            }
            else
            {
                ReadKey();
                LoadChallenge11();
            }
        }


        private void LoadChallenge11()
        {
            Clear();
            GameUtilities.TellTheStory("ROOM 11: You crawl your way into the deepest part of the cave. At the end of the tunnel, you find a huge room!\n" + "In the middle of the room a the largest Treasure Chest you've ever seen!\n");
            if (_hasTreasureKey == true)
            {

                GameUtilities.TellTheStory("You use your Treasure Key to open the chest.\n");
                GameUtilities.TellTheStory("YOU WIN!!\n");
                GameUtilities.TellTheStory("You've found Black Breads Treasure!! You're now richer than you could ever imagine!\n" + "Press any key to live your best life.\n");
                
                ReadKey();
                ExitApplication();

            }
            else
            {
                GameUtilities.TellTheStory("You try to pry open the Treasure Chest, but it won't open. It looks like you'll need to find a key to open it.\n");
                GameUtilities.TellTheStory("You decide to go head into the tunnel in front of you inside of turn back. The tunnel is so small you can only go out from here. \n" + "Press any key to continue.");
                ReadKey();
                LoadChallenge7();
            }
        }

        private void LoadChallenge8()
        {
            Clear();

            GameUtilities.TellTheStory("ROOM 8: You notice a shiny object on a dead pirate... \n" + "You take a closer look....\n" + "Its a Treasure Key!\n");

            GameUtilities.TellTheStory("Ahead of you is a tunnel that keeps going deeper into the cave.\n" + "You hear growling ahead, but something tells you the Treasure must be deeper in the cave. You go into the tunnel...\n" +
                                        "Press any key to continue.\n");

            GetKeyTrue();
            ReadKey();
            LoadChallenge9();
        }



        private void LoadChallenge2()
        {
            Clear();

            GameUtilities.TellTheStory($"ROOM 2: You get ambushed by a {_monster.Name} !!\n");
            _monster.AttackPlayer();
            _cave.Player.DecreaseHealth(20);

            GameUtilities.TellTheStory($"Fight {_monster.Name} !!\n" + "Press Key to Swing your Sword!");

            ReadKey();

            _cave.Player.SwingSword(_monster, 100);

            Clear();
            if (_cave.Player.HealthPoints <= 0)
            {
                IsDead();
            }
            else
            {
                GameUtilities.TellTheStory($"You have {_cave.Player.HealthPoints} health left.");
                GameUtilities.TellTheStory("ROOM 2: After you beat the Monster, you have the choice of going forward into in the only tunnel or going back.\n" +
                                            "1. Go Forward\n" +
                                            "2. Go Back");

                var userInput = ReadLine();
                switch (userInput)
                {
                    case "1":
                        LoadChallenge6();
                        break;
                    case "2":
                        LoadIntro();
                        break;
                    default:
                        WriteLine("Invalid Selection.");
                        break;
                }
            }
        }

        private void IsDead()
        {
            Clear();
            GameUtilities.TellTheStory("YOU DIED");
            ReadKey();
            StartGame();
        }
        //
        private void LoadChallenge6()
        {
            Clear();
            _cave.Player.DecreaseHealth(20);

            if (_cave.Player.HealthPoints <= 0)
            {
                IsDead();
            }
            else
            {

                GameUtilities.TellTheStory("ROOM 6: You see what looks like a partially opened treasure chest in front of you!\n" +
                                            "You open it and you get bitten by a CHEST MIMIC." + $"You have {_cave.Player.HealthPoints} health left.\n");

                GameUtilities.TellTheStory("You run into the first tunnel you see.\n" + "Press any key to continue.\n");
                ReadKey();
                LoadChallenge5();
            }

        }

        //Start Left -> Room 1
        private void LoadChallenge1()
        {
            Clear();

            GameUtilities.TellTheStory("ROOM 1: Challenge Description ADD LATER\n");

            GameUtilities.TellTheStory("Which Tunnel will you select?\n" +
                                         "1. Tunnel on the Left\n" +
                                         "2. Tunnel on the Right\n" +
                                         "3. Go back\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    LoadChallenge4();
                    break;
                case "2":
                    LoadChallenge5();
                    break;
                case "3":
                    LoadIntro();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }

        //Room 1 Right -> Room 5
        private void LoadChallenge5()
        {
            Clear();

            GameUtilities.TellTheStory("ROOM 5:\n");

            GameUtilities.TellTheStory("There are bats everywhere, you see a tunnel in front of you!\n" +
                                        "1. Go Forward\n" +
                                        "2. Go back\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    LoadChallenge10();
                    break;
                case "2":
                    LoadChallenge1();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }

        private void LoadChallenge10()
        {
            Clear();
            _cave.Player.DecreaseHealth(10);

            GameUtilities.TellTheStory("ROOM 10: YOU FIND AN OLD MINNING CART\n");

            GameUtilities.TellTheStory("Suddenly the walls start caving in on you! You think fast and jump into the minning cart, but you get hit with rocks!! \n" + "The mining cart starts rolling...\n" + $"You have {_cave.Player.HealthPoints} health left.\n" +
                                        "Press any key to continue. \n");

            if (_cave.Player.HealthPoints <= 0)
            {
                IsDead();
            }
            else
            {
                ReadKey();
                LoadChallenge3();
            }
        }

        //Room 1 Left -> Room 4
        private void LoadChallenge4()
        {
            Clear();
            _cave.Player.DecreaseHealth(50);
            GameUtilities.TellTheStory("ROOM 4: You walk into the middle of the room and then...\n" +
                                        "You fall into a SPIKE TRAP!!\n" + $"You have {_cave.Player.HealthPoints} health left.\n");
            GameUtilities.TellTheStory("You are forced to go back to Room 1.\n" +
                                        "Press any key to continue.\n");
            if (_cave.Player.HealthPoints <= 0)
            {
                IsDead();
            }
            else
            {
                ReadKey();
                LoadChallenge1();
            }
        }

        private bool ExitApplication()
        {
            Clear();
            WriteLine("Thanks for playing!");
            ReadKey();
            return false;
        }
    }
}