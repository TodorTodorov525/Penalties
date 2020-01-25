using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BaseClasses
{
    public class Goalkeeper : Player, IPlayer
    {
        [JsonProperty("GKskill")]
        private int GKskill { get; set; }

        public Goalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill, string team_name) : base(fname, lname, age, compusure, work_rate, team_name)
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

        public new string Print()
        {
            return base.Print() + " " + this.GetGoalkeeperSkill();
        }
    }
}