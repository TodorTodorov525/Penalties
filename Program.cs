﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BaseClasses;
using Helpers;
namespace Penalties
{
    class Program
    {
        private static List<Goalkeeper> listGoalies = new List<Goalkeeper>();
        private static List<Striker> listStrikers = new List<Striker>();
        private static List<Team> listTeamsChampionship = new List<Team>();
        private static readonly Validator v = new Validator();
        
        static void Main()
        {
            List<Goalkeeper> generated_goalkeepers = Generator.GenerateGoalkeepers(3);
            var x = Helper.ConvertToEnumerableJson(generated_goalkeepers);
           
            Console.WriteLine(x);
            List<Striker> generated_strikers = Generator.GenerateStrikers(3);
            var y = Helper.ConvertToEnumerableJson(generated_strikers);
            
            Console.WriteLine(y);

            Console.WriteLine("Hi, welcome to penalties game:\n");
            MainMenuChoice();
        }

        private static void MenuBuilder()
        {
            Console.WriteLine("Please choose one of the following:\n");
            for (int i = 0; i < Constants.MENU_SELECTIONS.Length; i++)
            {
                Console.WriteLine($"{(i + 1).ToString()}.{Constants.MENU_SELECTIONS[i]}");
            }
        }
        public static int MainMenuChoice()
        {
            MenuBuilder();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Creating a goalie...\n");
                    Helper.HowToCreateGoalkeeper();
                    CreateGoalieInteractive();
                    break;
                case "2":
                    Console.WriteLine("Creating a striker...\n");
                    Helper.HowToCreateStriker();
                    CreateStrikerInteractive();
                    break;
                case "3":
                    Console.WriteLine("Listing goalies\n");
                    Console.WriteLine("id\tFirst name\tLast name\tAge\tSkill");
                    ListGoalies();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine("Listing strikers\n");
                    Console.WriteLine("id\tFirst name\tLast name\tAge\tAccuracy");
                    ListStrikers();
                    Console.WriteLine();
                    break;
                case "5":
                    PenaltyGame();
                    break;
                case "6":
                    Match();
                    break;
                case "7":
                    Console.WriteLine("Generating players...");
                    string gknum, stnum;
                    Console.WriteLine("Enter number of goalkeepers you would want to generate");
                    gknum = Console.ReadLine();
                    try
                    {
                        Int32.Parse(gknum);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid number!");
                        MainMenuChoice();
                    }
                    int parsed_gknum = Int32.Parse(gknum);
                    Console.WriteLine("Enter number of strikers you would want to generate");
                    stnum = Console.ReadLine();
                    try
                    {
                        Int32.Parse(stnum);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid number!");
                        MainMenuChoice();
                    }
                    int parsed_stnum = Int32.Parse(stnum);

                   
                    List<Goalkeeper> generated_goalkeepers = Generator.GenerateGoalkeepers(parsed_gknum);
                    List<Striker> generated_strikers = Generator.GenerateStrikers(parsed_stnum);
                    listGoalies.AddRange(generated_goalkeepers);
                    listStrikers.AddRange(generated_strikers);
                    Console.WriteLine("Players have been generated");
                    Generator.SaveToJsonFreeAgents(listGoalies);
                    Generator.SaveToJsonFreeAgents(listStrikers);
                    Console.WriteLine("Players have been save to a JSON file");
                    break;
                case "8":
                    Console.WriteLine("Loading data from team file...");
                    Console.WriteLine("Enter filename with data for import:");
                    Console.WriteLine("Files:");
                    string[] files = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + Constants.DATA_FOLDER_NAME);
                    for(int i =0; i < files.Length; i++)
                    {
                        int index = files[i].LastIndexOf(Constants.DATA_FOLDER_NAME);
                        if (index > 0)
                            Console.WriteLine(files[i][index..]);
                    }

                    string fileForImport = Console.ReadLine();
                    listTeamsChampionship = Generator.PopulatePlayersToTeams(fileForImport);
                    Console.WriteLine("Data has been imported:");
                    break;
                case "9":
                    Console.WriteLine("Closing application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("This option is not defined");
                    break;
            }
            MainMenuChoice();
            return 0;
        }

        private static void Match()
        {
          
        }

        private static Goalkeeper CreateGoalieInteractive()
        {
            Console.WriteLine("Enter goalie first name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter goalie last name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter goalie age: ");
            string age = Console.ReadLine();
            Console.WriteLine("Enter goalie composure: ");
            string composure = Console.ReadLine();
            Console.WriteLine("Enter goalie work rate: ");
            string workRate = Console.ReadLine();
            Console.WriteLine("Enter goalie skill: ");
            string gk_skill = Console.ReadLine();
            try
            {
                int parsedAge = Int16.Parse(age);
                int parsedComposure = Int16.Parse(composure);
                int parsedWorkRate = Int16.Parse(workRate);
                int parsedSkill = Int16.Parse(gk_skill);
            }
            catch(Exception)
            {
                Console.WriteLine("Unsuccesfull creation!\nAge, composure work rate and skill must be integers!\nReturning to main menu.\n");
                return null;
            };
            var newGoalkeeper = CreateGoalkeeper(fname: fname, lname: lname, age: Int16.Parse(age), compusure: Int16.Parse(composure), work_rate: Int16.Parse(workRate), skill: Int16.Parse(gk_skill)); 
            if(newGoalkeeper == null)
            {
                Console.WriteLine("Goalkeeper not created!");
                MainMenuChoice();
                return newGoalkeeper;
            }
            Console.WriteLine("Goalkeeper created!");
            listGoalies.Add(newGoalkeeper);
            MainMenuChoice();
            return newGoalkeeper;
        }

        private static Striker CreateStrikerInteractive()
        {
            Console.WriteLine("Enter striker first name: ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter striker last name: ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter striker age: ");
            string age = Console.ReadLine();
            Console.WriteLine("Enter striker composure: ");
            string composure = Console.ReadLine();
            Console.WriteLine("Enter striker work rate: ");
            string workRate = Console.ReadLine();
            Console.WriteLine("Enter striker accuracy: ");
            string accuracy = Console.ReadLine();
            try
            {
                int parsedAge = Int16.Parse(age);
                int parsedComposure = Int16.Parse(composure);
                int parsedWorkRate = Int16.Parse(workRate);
                int parsedAccuracy = Int16.Parse(accuracy);
            }
            catch (Exception)
            {
                Console.WriteLine("Unsuccesfull creation!\nAge, composure, work rate and accuracy must be integers!\nReturning to main menu.\n");
                return null;
            };
            var newStriker = CreateStriker(fname: fname, lname: lname, age: Int16.Parse(age), compusure: Int16.Parse(composure), work_rate: Int16.Parse(workRate), accuracy: Int16.Parse(accuracy));
            if (newStriker == null)
            {
                Console.WriteLine("Striker not created!\n");
                MainMenuChoice();
                return newStriker;
            }
            Console.WriteLine("Striker created!\n");
            listStrikers.Add(newStriker);
            MainMenuChoice();
            return newStriker;
        }


        public static Goalkeeper CreateGoalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill)
        {
            if (v.ValidateGoalkeeper(fname, lname, age, compusure, work_rate, skill))
            {
                return new Goalkeeper(fname, lname, age, compusure, work_rate, skill);
            }
            return null;
        }

        public static Striker CreateStriker(string fname, string lname, int age, int compusure, int work_rate, int accuracy)
        {
            if (v.ValidateStriker(fname, lname, age, compusure, work_rate, accuracy))
            {
                return new Striker(fname, lname, age, compusure, work_rate, accuracy);
            }
            return null;
        }

        public static void ListGoalies()
        {
            int i = 0;
            foreach (Goalkeeper gk in listGoalies)
            {
                Console.WriteLine($"{++i}\t{gk.GetPlayerFirstName()}\t{gk.GetPlayerLastName()}\t{gk.GetPlayerAge()}\t{gk.GetGoalkeeperSkill()}");
            }
        }

        public static void ListStrikers()
        {
            int i = 0;
            foreach (Striker st in listStrikers)
            {
                Console.WriteLine($"{++i}\t{st.GetPlayerFirstName()}\t{st.GetPlayerLastName()}\t{st.GetPlayerAge()}\t{st.GetStrikerAccuracy()}");
            }
        }

        public static void PenaltyGame()
        {
            Goalkeeper selectedGk = Goalkeeper.GetRandomGoalkeeper(listGoalies); 
            Striker selectedStriker = Striker.GetRandomStriker(listStrikers);
            if (selectedGk == null)
            {
                Console.WriteLine("In order to play the game, a goalkeeper must be created.");
            };
            if (selectedStriker == null)
            {
                Console.WriteLine("In order to play the game, a goalkeeper must be created.");
            }
            else
            {
            Console.WriteLine($"The goalkeeper is {selectedGk.GetPlayerFirstName()} {selectedGk.GetPlayerLastName()} his skill is {selectedGk.GetGoalkeeperSkill()}");
            Console.WriteLine($"The striker is{selectedStriker.GetPlayerFirstName()} {selectedStriker.GetPlayerLastName()} his accuracy is {selectedStriker.GetStrikerAccuracy()}");
            Console.WriteLine("You are the striker!\nWhere do you want to shoot:\nL = Left\tC = Center\tR = Right");
            string shotDirection = Console.ReadLine();
            switch (shotDirection)
            {
                case "L":
                    break;
                case "C":
                    break;
                case "R":
                    break;
                default:
                    Console.WriteLine("Unrecognised direction");
                    PenaltyGame();
                    return;  
            }
            if (ShotSavedScored(shotDirection, selectedGk, selectedStriker))
                    Console.WriteLine("GOAL!!!");
            else
                    Console.WriteLine("The shot has been saved!");
            }
            // CalculateGame(shotDirection);
        }

        private static bool ShotSavedScored(string shotDirection, Goalkeeper gk, Striker st)
        {
            Random r = new Random();
            string[] GKJumpDirections = new string[] { "L", "C", "R"};
            string GKDirection = GKJumpDirections[r.Next(GKJumpDirections.Length)];
            return Algorythms.CalculateShotIsGoal(shotDirection, GKDirection, gk, st);
          //  return (shotDirection == GKDirection) && (gk.GetGoalkeeperSkill() > st.GetStrikerAccuracy()) ? true : false;
        }
    }
}
