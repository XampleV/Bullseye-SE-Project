using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
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

        public static Random _random = new Random(); // This will be our random generator variable.
        // we don't need 2 values for x,y we can grab like this:
        // for X: Cursor.Position.X
        // for Y: Cursor.Position.Y

        static public void MainFuncionEntry(string username, string mode)
        {
            //Make the Goal the First Time
            GoalPoint();

            // ready the threads
            //Thread currentGoal = new Thread(new ThreadStart(GoalPoint));
            Thread howPlayerDoing = new Thread(new ThreadStart(CloseOrNot));


            // start all threads
            //currentGoal.Start();
            howPlayerDoing.Start();


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


                if (scoreStuffX <= 30 * Difficulty && scoreStuffY <= 30 * Difficulty)
                {
                    Console.WriteLine($"YOU GOT IT\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                    Console.ReadLine();
                    Console.Clear();
                    GoalPoint();
                }
                else if (scoreStuffX <= 100 * Difficulty && scoreStuffY <= 100 * Difficulty)
                {
                    Console.WriteLine($"HOT!\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");

                }
                else if (scoreStuffX <= 600 * Difficulty && scoreStuffY <= 600 * Difficulty)
                {
                    Console.WriteLine($"Warmer\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX <= 800 * Difficulty && scoreStuffY <= 800 * Difficulty)
                {
                    Console.WriteLine($"It's Getting Pretty Chilly.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else if (scoreStuffX <= 1000 * Difficulty && scoreStuffY <= 1000 * Difficulty)
                {
                    Console.WriteLine($"You're too cold.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }
                else
                {
                    Console.WriteLine($"You're frozen.\ngoal:  x{goalXPos} y{goalYPos}\ncurrent: {heyX},{heyY}\nFar away values: {scoreStuffX},{scoreStuffY}\n------------");
                }








            }
        }
    }
}