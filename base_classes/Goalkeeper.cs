using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace BaseClasses
{
    public class Goalkeeper : Player
    {

        public int GKskill { get; set; }

        public Goalkeeper(string fname, string lname, int age, int compusure, int work_rate, int skill) : base( fname,  lname,  age,  compusure,  work_rate)
        {
            this.SetPlayerAge(age);
            this.SetPlayerComposure(compusure);
            this.SetPlayerWorkRate(work_rate);
            this.SetGKskill(skill);
            this.SetPlayerFirstName(fname);
            this.SetPlayerLastName(lname);
        }
        private void SetGKskill(int gkSkill)
        {
            this.GKskill = gkSkill;
        }

        public int GetGoalkeeperSkill() => this.GKskill;
    }
}