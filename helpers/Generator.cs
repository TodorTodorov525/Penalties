using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BaseClasses;
using Newtonsoft.Json;



namespace Helpers
{
    class Generator
    {
        public Generator()
        {

        }

        public List<Goalkeeper> GenerateGoalkeepers(int numberOFPlayers)
        {
            int i = 0;
            List<Goalkeeper> listGoalkeeper = new List<Goalkeeper>(numberOFPlayers);
            while (i < numberOFPlayers)
            {
                var random = new Random();
                int indexOfFirstName = random.Next(Constants.FIRST_NAMES.Length);
                int indexOfLastName = random.Next(Constants.FIRST_NAMES.Length);
                Goalkeeper newGoalkeeper = new Goalkeeper(Constants.FIRST_NAMES[indexOfFirstName], Constants.LAST_NAMES[indexOfLastName], random.Next(Constants.MIN_PLAYER_AGE, Constants.MIN_PLAYER_AGE), random.Next(Constants.MIN_PLAYER_COMPOSURE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_PLAYER_WORK_RATE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_GK_SKILL, Constants.MAX_GK_SKILL));
                listGoalkeeper.Add(newGoalkeeper);
                i++;
            }
            return listGoalkeeper;
        }

        public List<Striker> GenerateStrikers(int numberOFPlayers)
        {
            int i = 0;
            List<Striker> listStriker = new List<Striker>(numberOFPlayers);
            while (i < numberOFPlayers)
            {
                var random = new Random();
                int indexOfFirstName = random.Next(Constants.FIRST_NAMES.Length);
                int indexOfLastName = random.Next(Constants.FIRST_NAMES.Length);
                Striker newStriker = new Striker(Constants.FIRST_NAMES[indexOfFirstName], Constants.LAST_NAMES[indexOfLastName], random.Next(Constants.MIN_PLAYER_AGE, Constants.MAX_PLAYER_AGE), random.Next(Constants.MIN_PLAYER_COMPOSURE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_PLAYER_WORK_RATE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_STRIKER_ACCURACY, Constants.MAX_STRIKER_ACCURACY));
                listStriker.Add(newStriker);
                i++;
            }
            return listStriker;
        }


        public void PopulatePlayersToTeams()
        {
            List<Team> goalkeepers;
            string projectDir =  Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            
            if (File.Exists(projectDir + "/data/teams_with_players.json"))
            {
                string free_agent_file = projectDir + "/data/teams_with_players.json";
                goalkeepers = JsonConvert.DeserializeObject<List<Team>>(File.ReadAllText(free_agent_file));     
            }
        }


            
        }
     
    }

