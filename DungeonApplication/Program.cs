using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MonsterLibrary;
using DungeonLibrary;


namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Legend of the C#end Sword";

            Console.WriteLine("Welcome to the legend of the C#end Sword\n" +
                "o()xxxx[{:::::::::::::::::::>\n" +
                "In this adventure you will battle monsters and collect gold\n" +
                "If you find yourself low on health, return to the inn to rest for a small fee.\n" +
                "press any key to start you adventure");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Greetings adventurer, your story begins...\n");

            int score = 0;

            Random randGold = new Random();

            int gold = randGold.Next(1, 20);

            Weapon sword = new Weapon(1, 7, "Small Sword", 9, false);

            Player player = new Player("Noble Hero", 60, 4, 50, 60, Race.Warrior, sword);

            bool exit = false;

            do
            {

                Console.WriteLine(GetRoom());

                RedBlob br1 = new RedBlob();

                BlueBlob bb2 = new BlueBlob();

                BlueBlob bb3 = new BlueBlob("Blue Blob", 12, 11, 30, 20, 1, 9, "this BlueBlob is Slimey", true);

                PurpleBlob bb4 = new PurpleBlob();

                PurpleBlob bb5 = new PurpleBlob("Purple Blob", 15, 16, 40, 35, 5, 15, "this PurpleBlop is Slimey", true);

                Monster[] monsters = { br1, br1, br1, bb2, bb2, bb2, bb3, bb3, bb3, bb4, bb4, bb5 };

                Random rand = new Random();

                int randomNbr = rand.Next(monsters.Length);

                Monster monster = monsters[randomNbr];

                Console.WriteLine("\nIn this room you encounter a " + monster.Name);

                bool reload = false;
                do
                {
                    #region MENU

                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "I) Inn restore health\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:

                            Combat.DoBattle(player, monster);

                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated the {0}!\n", monster.Name);
                                Console.WriteLine("\nYou earned {0} gold", gold);
                                Console.ResetColor();
                                reload = true;
                                score++;
                                gold++;
                                

                            }

                            break;

                        case ConsoleKey.R:

                            Console.WriteLine("Run away!");

                            Console.WriteLine($"{monster.Name} attacked you as you flee!");

                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;

                            break;

                        case ConsoleKey.P:

                            Console.WriteLine("Player Info!");

                            Console.WriteLine(player);
                            Console.WriteLine("Monster defeated: " + score);
                            Console.WriteLine("Gold earned: " + gold);

                            break;

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

                            break;

                       case ConsoleKey.I:

                            //Console.WriteLine("You have entered the inn. You have restored your health by 1 point costing 1 gold, press any key to continue your quest");
                            //Console.ReadLine();
                       
                            
                            if (player.Life < 60 && gold > 1)
	                        {
                                gold--;
                                player.Life++;
	                        }
                            Console.WriteLine("You have rested and restored your health by 1 and the stay cost 1 gold");
                            break;


                        case ConsoleKey.X:
                        case ConsoleKey.E:

                            Console.WriteLine("Fair thee well adventurer");
                            
                            exit = true;

                            break;

                        default:

                            Console.WriteLine("Choice not recognized, please try again.");

                            break;



                    }

                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("YOU HAVE PERISHED");
                        Console.ResetColor();
                        exit = true;

                    }





                } while (!reload && !exit);
                
                
            } while (!exit);

            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
            Console.WriteLine("You aquired " + gold + " gold ");

            Console.WriteLine("Thank you for playing! press any key to exit");
            Console.ReadKey();

        }//End Main

        private static string GetRoom()
        {
            string[] rooms =
            {
                "You enter vast open field.",
                "You adventured through the forest of wisdom",
                "This room looks quite familar",
                "You understand the gravity of your situation and continue to press ahead",
                "You enter Doom Mountain",




            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;



        }
    }
}
