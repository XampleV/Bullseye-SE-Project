using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Json.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace Bullseye_SE_Project.functions
{
    class DataControl
    {
        public static string currentPath = @"C:\Users\Public\Documents\myData.txt";
        public static string json;
        public static dynamic users;
        public static string highestUser;
        public static int highestScore = 0;
        //public static var users;

        public static void InitializeCode()
        {
            CheckFile();
            LoadCurrentScores();
           
        }
        
        public static void CheckFile()
        {
            if (!File.Exists(currentPath))
            {
                string defaultJson = "{'database':[]}";
                Root desHasToMadeFirst = JsonConvert.DeserializeObject<Root>(defaultJson);
                string newJsonFileToBeWritten = JsonConvert.SerializeObject(desHasToMadeFirst, Formatting.Indented);
                using (StreamWriter file = File.CreateText(currentPath))
                {
                    file.Write(newJsonFileToBeWritten);
                    file.Close();
                    Console.WriteLine("Successfully created a database file.");
                }
            }
        } 
        public static void LoadCurrentScores()
        {

            using (StreamReader r = new StreamReader(currentPath))
            {
                json = r.ReadToEnd();
                r.Close();

            }
            users = JsonConvert.DeserializeObject<Root>(json);
            foreach (var i in users.database)
            {
                if ((int) Convert.ToInt32(i.score) > highestScore)
                {
                    highestScore = ((int)Convert.ToInt32(i.score));
                    highestUser = i.username;
                }

            }

        }
        public static void AddUserIntoDatabase(string playerName)
        {
            foreach (var i in users.database)
            {
                if ((string) i.username == playerName)
                {
                    return;
                }
            }
            AddNewUser(playerName);

        }
        public static void AddNewUser(string playerName)
        {
            string tempJson = "{'username':'"+playerName+"','score':'0'}";
            Database response = JsonConvert.DeserializeObject<Database>(tempJson);
            users.database.Add(response);

            string jsonToBeWritten = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter file = File.CreateText (currentPath))
            {
                file.Write(jsonToBeWritten);
                file.Close();
            }
            Console.WriteLine("User Added Successfully.");
        }
        public static void UpdateUserScore(string playerName, int time)
        {
            string title;
            // a stupid way to do it, but does the job...
            time = time / 10000000;
            if (time <= 10 && time <= 10)
            {
                title = "Peregrine Falcon";
            }
            else if(time <= 20 && time <= 20)
            {
                title = "Cheetah";
            }
            else if (time <= 40 && time <= 40)
            {
                title = "Green Iguana";
            }
            else if(time <= 100 && time <= 100)
            {
                title = "Giant Turtle";
            }
            else if (time <= 200 && time <= 200)
            {
                title = "Sloth";
            }
            else
            {
                title = "unknown";
            }
            foreach (var i in users.database)
            {
                if ((string) i.username == playerName)
                {
                    i.score = Convert.ToString(time);
                    i.title = title;
                }
            }
            PushNewScores();
        }
        public static void PushNewScores()
        {
            string jsonToBeWritten = JsonConvert.SerializeObject(users, Formatting.Indented);
            using (StreamWriter file = File.CreateText(currentPath))
            {
                file.Write(jsonToBeWritten);
                file.Close();
            }
        }

    }

    public class Database
    {
        public string username { get; set; }
        public string score { get; set; }
        public string title { get; set; }
    }

    public class Root
    {
        public List<Database> database { get; set; }
    }


}
