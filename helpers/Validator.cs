using BaseClasses;

namespace Helpers
{
   public class Validator
    {
        readonly Helper h = new Helper();
        public bool ValidatePlayer(string fname, string lname, int age, int compusure, int workRate)
        {
            if ((h.nameValidator(fname) && h.nameValidator(lname) &&
                h.checkIntInBounds(age, Constants.MIN_PLAYER_AGE, Constants.MAX_PLAYER_AGE) &&
                h.checkIntInBounds(compusure, Constants.MIN_PLAYER_COMPOSURE, Constants.MAX_PLAYER_COMPOSURE) &&
                h.checkIntInBounds(workRate, Constants.MIN_PLAYER_WORK_RATE, Constants.MAX_PLAYER_WORK_RATE)) == false)
            {
                return false;
            }

            return true;
        }

        public bool ValidateGoalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill)
        {
            if ((ValidatePlayer(fname, lname, age, compusure, work_rate) && h.checkIntInBounds(skill, Constants.MIN_GK_SKILL, Constants.MAX_GK_SKILL)) == false)
            {
                return false;
            }
            return true;
        }
    }
}
