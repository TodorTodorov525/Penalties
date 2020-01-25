using Newtonsoft.Json;

namespace BaseClasses
{
    public abstract class Player : IPlayer
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

        [JsonProperty("TeamName")]
        public string TeamName { get; set; } = "None";

        public Player(string fname, string lname, int age, int compusure, int work_rate, string team_name)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.Compusure = compusure;
            this.WorkRate = work_rate;
            if (team_name != "" )
                this.TeamName = team_name;
        }

        public string GetPlayerFirstName() => this.FirstName;

        public string GetPlayerLastName() => this.LastName;

        public int GetPlayerAge() => this.Age;

        public int GetPlayerComposure() => this.Compusure;

        public int GetPlayerWorkRate() => this.WorkRate;

        public string GetPlayerTeamName() => this.TeamName;

        public void SetPlayerTeamName(string TeamName) => this.TeamName = TeamName;

        public string Print()
        {
            return this.GetPlayerFirstName() + " " + this.GetPlayerLastName() + " " +
                this.GetPlayerAge() + " " + this.GetPlayerComposure() + " " +
                this.GetPlayerWorkRate() + " " + this.GetPlayerTeamName();
        }
    }
}