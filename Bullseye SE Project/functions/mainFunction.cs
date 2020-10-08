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
        // Stopwatch boi
        public static Stopwatch letsFindThatTime;
        public static long playersTime;

        public static Random _random = new Random(); // This will be our random generator variable.
        // we don't need 2 values for x,y we can grab like this:
        // for X: Cursor.Position.X
        // for Y: Cursor.Position.Y

        static public void MainFuncionEntry()
        {
            //Make the Goal the First Time
            GoalPoint();

            // ready the threads
            //Thread currentGoal = new Thread(new ThreadStart(GoalPoint));
            Thread howPlayerDoing = new Thread(new ThreadStart(CloseOrNot));


            // start all threads
            //currentGoal.Start();
            howPlayerDoing.Start();
            //This is watch
            letsFindThatTime = Stopwatch.StartNew();


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

                    Console.WriteLine($"YOU GOT IT\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\nYourTime : {(playersTime / 10000000)} \n------------");
                    mainFunctions.HowFast();
                    Console.ReadLine();

                    GoalPoint();
                }
                else if (scoreStuffX <= 40 * Difficulty && scoreStuffY <= 40 * Difficulty)
                {
                    Console.WriteLine($"YOU'RE ON FIRE!\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX <= 80 * Difficulty && scoreStuffY <= 80 * Difficulty)
                {
                    Console.WriteLine($"HOT!\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");

                }
                else if (scoreStuffX <= 200 * Difficulty && scoreStuffY <= 200 * Difficulty)
                {
                    Console.WriteLine($"Warmer\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX <= 400 * Difficulty && scoreStuffY <= 400 * Difficulty)
                {
                    Console.WriteLine($"You're cold.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX <= 800 * Difficulty && scoreStuffY <= 800 * Difficulty)
                {
                    Console.WriteLine($"You're ice cold.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX >= 801 * Difficulty && scoreStuffY >= 801 * Difficulty)
                {
                    Console.WriteLine($"You're frozen.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }








            }
        }

        public static void HowFast()
        {
            if ((playersTime / 10000000) >= 200)
            {
                Console.WriteLine("You are as slow as a sloth");
            }
            else if ((playersTime / 10000000) >= 100 && (playersTime / 10000000) < 200)
            {
                Console.WriteLine("Turtles get there at some point");
            }
            else if ((playersTime / 10000000) >= 40 && (playersTime / 10000000) < 100)
            {
                Console.WriteLine("Fast as a Green Iguana");
            }
            else if ((playersTime / 10000000) >= 20 && (playersTime / 10000000) < 40)
            {
                Console.WriteLine("This man is a cheetah");
            }
            else if ((playersTime / 10000000) >= 10 && (playersTime / 10000000) < 20)
            {
                Console.WriteLine("Man you're as fast as a Peregrine falcon");
            }
            else if ((playersTime / 10000000) <= 1 && (playersTime / 10000000) < 10)
            {
                Console.WriteLine("You cheated");
            }
        }
    }
}