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
            string mode;
            mode = "hard"; // temp
            // Greet them.
            Console.WriteLine("Welcome to Bullseye!");

            // Ask them to enter a username.
            Console.WriteLine("Please enter a username: ");

            // Create a string variable and get user input from the keyboard and store it in the variable.
            userName = Console.ReadLine();

            // Print the value of the variable (userName) which will display the input value.
            Console.WriteLine("Hello, " + userName);


            //Set the difficulty
            Console.WriteLine("Please enter how hard you want the game to be. Hard, Medium, or Easy");
            int playerDifficulty = Console.ReadLine().ToLower();

            switch (playerDifficulty)
            {
                case "hard":
                    Console.WriteLine("Oh, I hope you do well then.");
                    mainFunction.mainFunctions.Difficuly() = 1.5;
                    break;
                case "medium":
                    Console.WriteLine("Yeah thats where I would play at too.");
                    mainFunction.mainFunctions.Difficuly() = 1;
                    break;
                case "easy":
                    Console.WriteLine("Feeling casual today huh?");
                    mainFunction.mainFunctions.Difficuly() = 2;
                    break;
            }

        }
    }
}