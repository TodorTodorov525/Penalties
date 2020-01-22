using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BaseClasses
{
    class Team
    {
        [JsonProperty("TeamName")]
        private string TeamName { get; set; }

        [JsonProperty("Strikers")]
        private List<Striker> TeamStrikers = new List<Striker>(5);

        [JsonProperty("Goalkeepers")]
        private List<Goalkeeper> TeamGoalkeepers = new List<Goalkeeper>(3);

        public Team()
        {

        }

        public void SetTeamName(string teamName)
        {
            TeamName = teamName;
        }

        public void AddOneStriker(Striker st)
        {
            this.TeamStrikers.Add(st);
        }

        public void AddManyStrikers(List<Striker> listSt)
        {
            TeamStrikers.Union(listSt);   
        }

        public void AddOneGoalkeeper(Goalkeeper gk)
        {
            this.TeamGoalkeepers.Add(gk);
        }

        public void AddManyGoalkeepers(List<Goalkeeper> listGK)
        {
            TeamGoalkeepers.Union(listGK);
        }
        public string GetTeamName() => this.TeamName;

        public List<Striker> GetTeamStrikers() => this.TeamStrikers;

        public List<Goalkeeper> GetTeamGoalkeepers() => this.TeamGoalkeepers;

    }
}
