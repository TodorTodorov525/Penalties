using BaseClasses;

namespace Helpers
{
   public class Validator
    {
        public bool ValidatePlayer(string fname, string lname, int age, int compusure, int workRate)
        {
            if ((Helper.NameValidator(fname) && Helper.NameValidator(lname) &&
                Helper.CheckIntInBounds(age, Constants.MIN_PLAYER_AGE, Constants.MAX_PLAYER_AGE) &&
                Helper.CheckIntInBounds(compusure, Constants.MIN_PLAYER_COMPOSURE, Constants.MAX_PLAYER_COMPOSURE) &&
                Helper.CheckIntInBounds(workRate, Constants.MIN_PLAYER_WORK_RATE, Constants.MAX_PLAYER_WORK_RATE)) == false)
            {
                return false;
            }

            return true;
        }

        public bool ValidateGoalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill)
        {
            if ((ValidatePlayer(fname, lname, age, compusure, work_rate) && Helper.CheckIntInBounds(skill, Constants.MIN_GK_SKILL, Constants.MAX_GK_SKILL)) == false)
            {
                return false;
            }
            return true;
        }

        public bool ValidateStriker(string fname, string lname, int age, int compusure, int work_rate, int accuracy)
        {
            if ((ValidatePlayer(fname, lname, age, compusure, work_rate) && Helper.CheckIntInBounds(accuracy, Constants.MIN_STRIKER_ACCURACY, Constants.MAX_STRIKER_ACCURACY)) == false)
            {
                return false;
            }
            return true;
        }
    }
}
