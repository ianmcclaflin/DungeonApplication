﻿using System;
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
            Console.WriteLine("Greetings adventurer, your story begins...\n");

            int score = 0;

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

                Monster[] monsters = { br1, br1, br1, bb2, bb2, bb2, bb3, bb4, bb4, bb5 };

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
                                Console.ResetColor();
                                reload = true;
                                score++;


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

                            break;

                        case ConsoleKey.M:

                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);

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

            Console.WriteLine("You defeated " + score + " monsters" + ((score ==1) ? "." : "s."));



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
