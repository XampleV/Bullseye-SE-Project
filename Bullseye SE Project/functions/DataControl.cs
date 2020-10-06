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
        public static Root users;
        public static string highestUser;
        public static int highestScore = 0;
        //public static var users;

        public static void InitializeCode()
        {
            LoadCurrentScores();
            DoesUserAlreadyExist("ok");
           
        }
        
         public static void LoadCurrentScores()
        {

            using (StreamReader r = new StreamReader(currentPath))
            {
                json = r.ReadToEnd();
                r.Close();

            }
            Root users = JsonConvert.DeserializeObject<Root>(json);
            foreach (var i in users.database)
            {
                if ((int) Convert.ToInt32(i.score) > highestScore)
                {
                    highestScore = ((int)Convert.ToInt32(i.score));
                    highestUser = i.username;
                }

            }

            Console.WriteLine(highestUser);

            Console.ReadLine();
            //var jsonObj = new JavaScriptSerializer.Deserialize<RootObj>(o1);



        }
        public static bool DoesUserAlreadyExist(string playerName)
        {
            //Root users = JsonConvert.DeserializeObject<Root>(json);
            foreach (var i in users.database)
            {
                if ((string) i.username == playerName)
                {
                    Console.WriteLine("It's true.");
                    Console.ReadLine();

                    return true;
                }
            }

            Console.WriteLine("It's false;");
            Console.ReadLine();
            return false;
        }
        public class Database
        {
            public  string username { get; set; }
            public  string score { get; set; }
        }

        public class Root
        {
            public List<Database> database { get; set; }
        }




    }
}
