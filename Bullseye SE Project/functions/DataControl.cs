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
        public static string currentPath = @"C:\Users\alshoubaki_mohammad\AppData\data.txt";
        public static string json;
        public static string highestUser;

        public static void InitializeCode()
        {
            LoadCurrentScores();
        }
        public static void LoadCurrentScores()
        {
            using (StreamReader r = new StreamReader(currentPath))
            {
                json = r.ReadToEnd();
                r.Close();

            }
            var users = JObject.Parse(json);
            int tempScore = 0;
            foreach (var i in users["database"])
            {
                if ((int)i["score"] >= tempScore)
                {
                    tempScore = (int)i["score"];
                    highestUser = (string)i["username"];
                }
            }
            Console.WriteLine(highestUser);

            Console.ReadLine();
            //var jsonObj = new JavaScriptSerializer.Deserialize<RootObj>(o1);



        }
        public static bool DoesUserAlreadyExist()
        {


            return true;
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
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
    public class JsonData
    {
        public string username { get; set; }
        public int score { get; set; }
    }
}
