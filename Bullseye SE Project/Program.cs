using System;

namespace Bullseye_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();
        }

        static void Introduction()
        {
            string userName;
            string Difficulty;
            // Greet them.
            Console.WriteLine("Welcome to Bullseye!");

            // Ask them to enter a username.
            Console.WriteLine("Please enter a username: ");

            // Create a string variable and get user input from the keyboard and store it in the variable.
            userName = Console.ReadLine();

            // Print the value of the variable (userName) which will display the input value.
            Console.WriteLine("Hello, " + userName);

            Console.WriteLine("Would you like to play? (Y/N)");
            //Console.Write();
            string Choice = Console.ReadLine();

            if (Choice == "YES")
            {
                while (true)
                {
                    Console.WriteLine("What difficulty? Easy, Medium, or Hard?");
                    Difficulty = Console.ReadLine().ToLower();
                    if (Difficulty == "hard" || Difficulty == "medium" || Difficulty == "easy")
                    {
                        break;
                    }
                    Console.WriteLine("Please enter either 'hard', 'medium', or 'easy'");
                    
                }
                Console.ReadLine();
                functions.mainFunctions.MainFunctionEntry(userName, Difficulty);
            }
            else if (Choice == "NO")
            {
                Console.WriteLine("Have a great day then!");
            }
        }
    }
}