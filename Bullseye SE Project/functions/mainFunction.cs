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

        public static Random _random = new Random(); // This will be our random generator variable.
        // we don't need 2 values for x,y we can grab like this:
        // for X: Cursor.Position.X
        // for Y: Cursor.Position.Y

        static public void MainFuncionEntry()
        {
            // ready the threads
            Thread currentPositionLoop = new Thread(new ThreadStart(HowCloseThread));

      
                // start all threads
                currentPositionLoop.Start();
            
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
    }
}