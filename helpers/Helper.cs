using System.Text.RegularExpressions;

namespace Helpers
{
    class Helper
    {
        public bool checkIntInBounds(int number, int min, int max) => (number < min) || (number > max) ? false : true;

        //add uppercase and only symbols, probably regex
        public bool nameValidator(string name) => (Regex.Match(name, @"([A-Z])\w{3,20}").Success) ? true : false;

        public void HowToCreateGoalkeeper()
        {
            System.Console.WriteLine("How to create a goalkeeper\n" + $"The goalie's name must be greater than {3} characters and it shall contain only characters." +
                $"The goalie's skill must be between {Constants.MIN_PLAYER_AGE} and {Constants.MAX_PLAYER_AGE}" + $"The goalie's composure must be between {Constants.MIN_PLAYER_COMPOSURE} and {Constants.MAX_PLAYER_COMPOSURE}" +
                $"The goalie's work rate must be between {Constants.MIN_PLAYER_WORK_RATE} and {Constants.MAX_PLAYER_WORK_RATE}\n\n");
        }


    }
}
