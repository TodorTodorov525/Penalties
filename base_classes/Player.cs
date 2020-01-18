using Helpers;
using System;
namespace BaseClasses
{
    public abstract class Player
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        // mental attributes
        private int Compusure { get; set; }

        private int WorkRate { get; set; }

        public Player(string fname, string lname, int age, int compusure, int work_rate)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.Compusure = compusure;
            this.WorkRate = work_rate;
        }

        public void SetPlayerFirstName(string name)
        {
            this.FirstName = name;
        }

        public void SetPlayerLastName(string name)
        {
            this.LastName = name;
        }

        public void SetPlayerAge(int age)
        {       
            this.Age = age;
        }

        public void SetPlayerComposure(int compusure)
        {
            this.Compusure = compusure;
        }

        public void SetPlayerWorkRate(int workRate)
        {
            this.WorkRate = workRate;
        }
        public string GetPlayerFirstName() => this.FirstName;

        public string GetPlayerLastName() => this.LastName;

        public int GetPlayerAge() => this.Age;

        public int GetPlayerComposure() => this.Compusure;

        public int GetPlayerWorkRate() => this.WorkRate;
    }
}