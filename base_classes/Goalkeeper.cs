using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace BaseClasses
{
    public class Goalkeeper : Player
    {

        public int GKskill { get; set; }

        public Goalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill) : base(fname, lname, age, compusure, work_rate)
        {
            GKskill = skill;
        }
   

        public int GetGoalkeeperSkill() => this.GKskill;

        public static Goalkeeper GetRandomGoalkeeper(List<Goalkeeper> lgk)
        {
            if (lgk.Count == 0)
            {
                return null;
            }
            var random = new Random();
            int indexOfGoalkeeper = random.Next(lgk.Count);
            return lgk[indexOfGoalkeeper];
        }
    }
}