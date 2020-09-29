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

        public static Random _random = new Random(); // This will be our random generator variable.
        // we don't need 2 values for x,y we can grab like this:
        // for X: Cursor.Position.X
        // for Y: Cursor.Position.Y

        static public void MainFunctionEntry()
        {
            //Make the Goal the First Time
            GoalPoint();

            // ready the threads
            Thread currentPositionLoop = new Thread(new ThreadStart(HowCloseThread));
            //Thread currentGoal = new Thread(new ThreadStart(GoalPoint));
            Thread howPlayerDoing = new Thread(new ThreadStart(CloseOrNot));

      
                // start all threads
                currentPositionLoop.Start();
                //currentGoal.Start();
                howPlayerDoing.Start();


        }

        public static void HowCloseThread()
        {
            //Here we'll loop constantly, I'll grab the position of the mouse and calculate the pixels.
            while (true)
            {
                mouseXPos = Cursor.Position.X;
                mouseYPos = Cursor.Position.Y;
                //Console.WriteLine(Cursor.Position.Y);
                Thread.Sleep(30);
                //push
            }
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
            while (true) {
                scoreStuffX = goalXPos - mouseXPos;
                scoreStuffY = goalYPos - mouseYPos;

                if (scoreStuffX >= 1000 && scoreStuffY >=1000)
                {
                    Console.WriteLine("Too Cold.");
                } else if (scoreStuffX >= 600 && scoreStuffY >= 600)
                {
                    Console.WriteLine("Warmer");
                } else if (scoreStuffX >= 200 && scoreStuffY >= 200)
                {
                    Console.WriteLine("HOT!");
                }
                else if (scoreStuffX >= 60 && scoreStuffY >= 60)
                {
                    Console.WriteLine("Super HOT!");
                }
                else if (scoreStuffX >= 30 && scoreStuffY >= 30)
                {
                    Console.WriteLine("Winner");
                    PlayAgain();
                }

                Thread.Sleep(2000);
            }
        }

        //Play again or not
        public static void PlayAgain()
        {
            Thread currentPositionLoop = new Thread(new ThreadStart(HowCloseThread));
            Thread howPlayerDoing = new Thread(new ThreadStart(CloseOrNot));

            Console.WriteLine("If you want to play again please type yes. If not just type no.");
            playAgain = Console.ReadLine().ToLower();

            if (playAgain == "yes")
            {
                Console.WriteLine("Then lets go.");
                MainFunctionEntry();
            }
            else
            {
                Console.WriteLine("Thats too bad. Guess I'll cya later.");
                howPlayerDoing.Abort();
                currentPositionLoop.Abort();
            }
        }
    }
}