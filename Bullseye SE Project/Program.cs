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
            userName = Console.ReadLine().ToLower();

            // Print the value of the variable (userName) which will display the input value.
            Console.WriteLine("Hello, " + userName);


            //Set the difficulty
            Console.WriteLine("Please enter how hard you want the game to be. Hard, Medium, or Easy");
            string playerDifficulty = Console.ReadLine().ToLower();

            switch (playerDifficulty)
            {
                case "hard":
                    Console.WriteLine("Oh, I hope you do well then.");
                    functions.mainFunctions.Difficulty = 0.5m;
                    break;
                case "medium":
                    Console.WriteLine("Yeah thats where I would play at too.");
                    functions.mainFunctions.Difficulty = 1;
                    break;
                case "easy":
                    Console.WriteLine("Feeling casual today huh?");
                    functions.mainFunctions.Difficulty = 2;
                    break;
            }

            Console.WriteLine("Do you want to play now? Yes or No");
            string playOrNot = Console.ReadLine().ToLower();

            switch (playOrNot)
            {
                case "yes":
                    functions.mainFunctions.MainFuncionEntry(userName);
                    break;
                case "no":
                    Console.WriteLine("Too bad.");
                    break;
                default:
                    Console.WriteLine("That imput doesn't exist.");
                    break;
            }




            //Test for commit
        }
    }
}