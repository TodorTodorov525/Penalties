﻿using System;
using System.Collections.Generic;
using System.IO;
using BaseClasses;
using Newtonsoft.Json;

namespace Helpers
{
    class Generator
    {
        public Generator()
        {

        }

        public static List<Goalkeeper> GenerateGoalkeepers(int numberOFPlayers)
        {
            int i = 0;
            List<Goalkeeper> listGoalkeeper = new List<Goalkeeper>(numberOFPlayers);
            while (i < numberOFPlayers)
            {
                var random = new Random();
                int indexOfFirstName = random.Next(Constants.FIRST_NAMES.Length);
                int indexOfLastName = random.Next(Constants.FIRST_NAMES.Length);
                Goalkeeper newGoalkeeper = new Goalkeeper(Constants.FIRST_NAMES[indexOfFirstName], Constants.LAST_NAMES[indexOfLastName], random.Next(Constants.MIN_PLAYER_AGE, Constants.MAX_PLAYER_AGE), random.Next(Constants.MIN_PLAYER_COMPOSURE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_PLAYER_WORK_RATE, Constants.MAX_PLAYER_COMPOSURE), random.Next(Constants.MIN_GK_SKILL, Constants.MAX_GK_SKILL));
                listGoalkeeper.Add(newGoalkeeper);
                i++;
            }
            return listGoalkeeper;
        }

        public static List<Striker> GenerateStrikers(int numberOFPlayers)
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


        public static List<Team> PopulatePlayersToTeams(string fileForImport)
        {
            List<Team> goalkeepers;
            string projectDir =  Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            if (!File.Exists(projectDir + $"/data/{fileForImport}.json"))
                return null;

            string free_agent_file = projectDir + $"/data/{fileForImport}.json";
            goalkeepers = JsonConvert.DeserializeObject<List<Team>>(File.ReadAllText(free_agent_file));
            return goalkeepers;
        }

        public static void SaveToJsonFreeAgents<T>(IEnumerable<T> list) where T : IPlayer
        {
            string CurrrentTimestamp = Helper.CurrentTimestamp();
            string FileName = CurrrentTimestamp + ".json";
            string newFile, folder;
            if (list is List<Goalkeeper>)
                folder = "goalkeeper";
            else if (list is List<Striker>)
                folder = "striker";
            else
                folder = "other";
            newFile = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + $"/data/{folder}/" + FileName;
            FileInfo file = new FileInfo(newFile);
            file.Directory.Create();
           
            File.WriteAllText(newFile, Helper.ConvertToEnumerableJson(list));
        }
    }
}

