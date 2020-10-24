using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;


namespace Bullseye_Project.functions
{
    class mainFunctions
    {
        public static int mouseXPos;
        public static int mouseYPos;
        public static int goalXPos;
        public static int goalYPos;

        public static int scoreStuffX;
        public static int scoreStuffY;

        public static string playAgain;

        public static decimal Difficulty;

        public static int userScore;

        public static string name;

        // Stopwatch boi
        public static Stopwatch letsFindThatTime;
        public static long playersTime;

        public static Random _random = new Random(); // This will be our random generator variable.
        // we don't need 2 values for x,y we can grab like this:
        // for X: Cursor.Position.X
        // for Y: Cursor.Position.Y

        static public void MainFuncionEntry(string username)
        {
            name = username;
            // Get current details / scores. If there are none, then it will make one for the user.
            Bullseye_SE_Project.functions.DataControl.InitializeCode();
            userScore = GetCurrentScore(name);
            Console.WriteLine($"Your highest score so far: {Convert.ToString(userScore)} seconds.\nClick ENTER to start...");
            Console.ReadLine();
            //Make the Goal the First Time
            GoalPoint();

            // ready the threads
            //Thread currentGoal = new Thread(new ThreadStart(GoalPoint));
            Thread howPlayerDoing = new Thread(new ThreadStart(CloseOrNot));


            // start all threads
            //currentGoal.Start();
            howPlayerDoing.Start();
            letsFindThatTime = Stopwatch.StartNew();


        }


        public static int GetCurrentScore(string playerName)
        {
            // there is an easier way to do this, we don't have to loop through it but eh.
            // i don't feel like changing the structure again
            foreach (var i in Bullseye_SE_Project.functions.DataControl.users.database)
            {
                if (i.username == playerName)
                {
                    return Convert.ToInt32(i.score);
                }
            }
            Bullseye_SE_Project.functions.DataControl.AddNewUser(playerName);
            return 0;
        }
        //Find the goal point to hover at
        public static void GoalPoint()
        {

            //Generate two seperate points set as the goal and then hand to the player
            goalXPos = _random.Next(1920);
            goalYPos = _random.Next(1080);
            Console.WriteLine($"The goal is x{goalXPos} y{goalYPos}");
        }

        //how well the palyer did
        public static void CloseOrNot()
        {
            while (true)
            {
                Thread.Sleep(100);
                int heyX = Cursor.Position.X;
                int heyY = Cursor.Position.Y;
                scoreStuffX = goalXPos - heyX;
                scoreStuffY = goalYPos - heyY;

                if (scoreStuffX < 0)
                {
                    scoreStuffX = scoreStuffX * -1;
                }
                if (scoreStuffY < 0)
                {
                    scoreStuffY = scoreStuffY * -1;
                }


                if (scoreStuffX <= 5 * Difficulty && scoreStuffY <= 5 * Difficulty)
                {
                    //This is the players current time
                    letsFindThatTime.Stop();
                    playersTime = letsFindThatTime.ElapsedTicks;

                    Bullseye_SE_Project.functions.DataControl.UpdateUserScore(name, Convert.ToInt32(playersTime));

                    Console.WriteLine($"YOU GOT IT\nYour Time : {(playersTime / 10000000)} \n------------\nDo you want to play again?");
                    string yesorno = Console.ReadLine().ToLower();
                    if (yesorno == "no")
                    {
                        System.Environment.Exit(1);
                    }

                    GoalPoint();
                }
                else if (scoreStuffX <= 40 * Difficulty && scoreStuffY <= 40 * Difficulty)
                {
                    Console.WriteLine($"YOU'RE ON FIRE!");
                }
                else if (scoreStuffX <= 80 * Difficulty && scoreStuffY <= 80 * Difficulty)
                {
                    Console.WriteLine($"HOT!");

                }
                else if (scoreStuffX <= 200 * Difficulty && scoreStuffY <= 200 * Difficulty)
                {
                    Console.WriteLine($"Warmer");
                }
                else if (scoreStuffX <= 400 * Difficulty && scoreStuffY <= 400 * Difficulty)
                {
                    Console.WriteLine($"You're cold.");
                }
                else if (scoreStuffX <= 800 * Difficulty && scoreStuffY <= 800 * Difficulty)
                {
                    Console.WriteLine($"You're ice cold.");
                }
                else if (scoreStuffX >= 801 * Difficulty && scoreStuffY >= 801 * Difficulty)
                {
                    Console.WriteLine($"You're frozen.");
                }


                //





            }
        }
    }
}