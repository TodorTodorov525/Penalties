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
            var test = (st.GetStrikerAccuracy() * st.GetPlayerComposure()) / (10 * (Constants.MAX_PLAYER_COMPOSURE - st.GetPlayerComposure()));
            //var test = (st.GetStrikerAccuracy() / 10 * ((Constants.MAX_PLAYER_COMPOSURE - st.GetPlayerComposure()) / st.GetPlayerComposure()));
            var r = rand.Next(1, 20);
            if (r > (st.GetStrikerAccuracy() / 10 * (st.GetStrikerAccuracy() * st.GetPlayerComposure()) / (10 * (Constants.MAX_PLAYER_COMPOSURE - st.GetPlayerComposure()))))
            {
                Console.WriteLine("striker missed");
                return false;
            }
            else if(GoalkeeperDirection == ShotDirection)
            {
                // true = goal, false = gk save
                return rand.Next(1, 10) > (gk.GetGoalkeeperSkill() / 10);
            }
            return true;
        }
    }
}
