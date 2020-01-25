using BaseClasses;
using System;

namespace Helpers
{
    class Algorythms
    {
        // false = no goal, true = goal
        public static bool CalculateShotIsGoal(string ShotDirection, string GoalkeeperDirection, Goalkeeper gk, Striker st)
        {
            Random rand = new Random();
            int AccuracyAndComposure = (st.GetStrikerAccuracy() * st.GetPlayerComposure()) / (10 * (Constants.MAX_PLAYER_COMPOSURE - st.GetPlayerComposure()));      
            if (rand.Next(1, 20) > AccuracyAndComposure)
            {
                Console.WriteLine("Striker missed.");
                return false;
            }
            else if((GoalkeeperDirection == ShotDirection) && (rand.Next(1, 10) < (gk.GetGoalkeeperSkill() / 10)))
            {
                Console.WriteLine("The goalkeeper saved.");
                return false;
            }
            return true;
        }
    }
}
