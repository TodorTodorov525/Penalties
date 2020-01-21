using Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BaseClasses
{
    public abstract class Player
    {
        [JsonProperty("FirstName")]
        private string FirstName { get; set; }

        [JsonProperty("LastName")]
        private string LastName { get; set; }

        [JsonProperty("Age")]
        private int Age { get; set; }

        // mental attributes
        [JsonProperty("Compusure")]
        private int Compusure { get; set; }

        [JsonProperty("WorkRate")]
        private int WorkRate { get; set; }

        public Player(string fname, string lname, int age, int compusure, int work_rate)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.Compusure = compusure;
            this.WorkRate = work_rate;
        }

        public string GetPlayerFirstName() => this.FirstName;

        public string GetPlayerLastName() => this.LastName;

        public int GetPlayerAge() => this.Age;

        public int GetPlayerComposure() => this.Compusure;

        public int GetPlayerWorkRate() => this.WorkRate;



    }
}