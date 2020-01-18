using System;
using System.Collections.Generic;
using BaseClasses;
using Helpers;
namespace Penalties
{
    class Program
    {
        private static List<Goalkeeper> listGoalies = new List<Goalkeeper>();
        private static Helper h = new Helper();
        private static Validator v = new Validator();
        static void Main(string[] args)
        {
            Console.WriteLine("\tHi, welcome to penalties game:\n");
            MainMenuChoice();
        }

        public static int MainMenuChoice()
        {
            
            Console.WriteLine("Please choose one of the following:\n1.Create a goalkeeper\n2.List goalkeepers\n3.Exit\n\n");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    Console.WriteLine("Creating a goalie...\n");
                    h.HowToCreateGoalkeeper();
                    CreateGoalieInteractive();
                    break;
                case "2":
                    Console.WriteLine("Listing goalies\n");
                    ListGoalies();
                    break;
                case "3":
                    Console.WriteLine("Closing application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Not good number");
                    break;
            }
            MainMenuChoice();
            return 0;
        }

        public static Goalkeeper CreateGoalieInteractive()
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


        public static Goalkeeper CreateGoalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill)
        {
            if (v.ValidateGoalkeeper(fname, lname, age, compusure, work_rate, skill))
            {
                return new Goalkeeper(fname, lname, age, compusure, work_rate, skill);
            }
            return null;
        }

        public static void ListGoalies()
        {
            foreach(Goalkeeper gk in listGoalies)
            {
                int i = 0;
                Console.WriteLine($"{i + 1}\t{gk.GetPlayerFirstName()}\t{gk.GetPlayerLastName()}\t{gk.GetPlayerAge()}\t{gk.GetGoalkeeperSkill()}");
            }
        }
    }
}
