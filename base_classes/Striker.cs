using System;
using System.Collections.Generic;
using System.Text;
using BaseClasses;

namespace BaseClasses
{
    public class Striker : Player
    { 
        public int ShotAccuracy { get; set; }

        public Striker(string fname, string lname, int age, int compusure, int work_rate, int shotAccuracy) : base(fname, lname, age, compusure, work_rate)
        {
            ShotAccuracy = shotAccuracy;
        }

        public int GetStrikerAccuracy() => this.ShotAccuracy;

        public static Striker GetRandomStriker(List<Striker> ls)
        {
            if(ls.Count == 0)
            {
                return null;
            }
            var random = new Random();
            int indexOfStriker = random.Next(ls.Count);
            return ls[indexOfStriker];
        }
    }
}
