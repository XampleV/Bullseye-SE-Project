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
            string tempJson = "{'username':'"+playerName+"','score':'1'}";
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

    }
    public class Database
    {
        public string username { get; set; }
        public string score { get; set; }
    }

    public class Root
    {
        public List<Database> database { get; set; }
    }


}
