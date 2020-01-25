using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
   static class Constants
    {
        public const int MIN_GK_SKILL = 1 ;
        public const int MAX_GK_SKILL = 99;
        public const int MIN_STRIKER_ACCURACY = 1;
        public const int MAX_STRIKER_ACCURACY = 99;
        public const int MIN_PLAYER_AGE = 14;
        public const int MAX_PLAYER_AGE = 53;
        public const int MIN_PLAYER_COMPOSURE = 1;
        public const int MAX_PLAYER_COMPOSURE = 20;
        public const int MIN_PLAYER_WORK_RATE = 1;
        public const int MAX_PLAYER_WORK_RATE = 20;
        public static string[] MENU_SELECTIONS = {"Create a goalkeeper(Free agent)", "Create a striker(Free agent)", 
            "List goalkeepers", "List strikers", 
            "Single penalty", "Play a match(5 strikers required)", 
            "Generate goalkeepers and strikers(Free agents)", "Load data from team file", 
            "Transfer goalkeeper", "Transfer striker", 
            "Exit" };
        public static string[] FIRST_NAMES = { "Bozhur", "Yatzo", "Lubomir", "Spas", "Assen" };
        public static string[] LAST_NAMES = { "Sotirov", "Alexov", "Bachev", "Mihailov", "Zhelev" };
        public static string DATA_FOLDER_NAME = "/data/";
    }
}
