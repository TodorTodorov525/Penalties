using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BaseClasses;
namespace Helpers
{
     class Helper
    {
        public static bool  CheckIntInBounds(int number, int min, int max) => (number < min) || (number > max) ? false : true;

        //add uppercase and only symbols, probably regex
        public static bool NameValidator(string name) => (Regex.Match(name, @"([A-Z])\w{3,20}").Success) ? true : false;

        public static void HowToCreateGoalkeeper()
        {
            System.Console.WriteLine("How to create a goalkeeper\n" + $"The goalie's name must be greater than {3} characters and it shall contain only characters.\n" +
                $"The goalie's skill must be between {Constants.MIN_PLAYER_AGE} and {Constants.MAX_PLAYER_AGE}\n" + $"The goalie's composure must be between {Constants.MIN_PLAYER_COMPOSURE} and {Constants.MAX_PLAYER_COMPOSURE}\n" +
                $"The goalie's work rate must be between {Constants.MIN_PLAYER_WORK_RATE} and {Constants.MAX_PLAYER_WORK_RATE}.\nThe goalie's skill must be between {Constants.MIN_GK_SKILL} and {Constants.MAX_GK_SKILL}.\n");
        }

        public static void HowToCreateStriker()
        {
            System.Console.WriteLine("How to create a striker\n" + $"The striker's name must be greater than {3} characters and it shall contain only characters.\n" +
                $"The striker's skill must be between {Constants.MIN_PLAYER_AGE} and {Constants.MAX_PLAYER_AGE}.\n" + $"The goalie's composure must be between {Constants.MIN_PLAYER_COMPOSURE} and {Constants.MAX_PLAYER_COMPOSURE}.\n" +
                $"The striker's work rate must be between {Constants.MIN_PLAYER_WORK_RATE} and {Constants.MAX_PLAYER_WORK_RATE}.\nThe striker's accuracy must be between {Constants.MIN_STRIKER_ACCURACY} and {Constants.MAX_STRIKER_ACCURACY}.\n");
        }

        public static string ConvertToEnumerableJson<T>(IEnumerable<T> arg) where T : IPlayer
        {
            return  JsonConvert.SerializeObject(arg);
        }

        public static string CurrentTimestamp()
        {
            DateTime date1 = new DateTime(1970, 1, 1);
            TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - date1.Ticks);
            return Convert.ToString(ts.TotalSeconds);
        }

        public static int InputNumberFromConsole()
        {
            string input = Console.ReadLine();
            try
            {
                Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number!");
                InputNumberFromConsole();
            }
            return Int32.Parse(input);
        }
    }
}
