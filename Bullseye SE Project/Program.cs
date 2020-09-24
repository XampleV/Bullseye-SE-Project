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
            // Greet them.
            Console.WriteLine("Welcome to Bullseye!");

            // Ask them to enter a username.
            Console.WriteLine("Please enter a username: ");

            // Create a string variable and get user input from the keyboard and store it in the variable.
            string userName = Console.ReadLine();

            // Print the value of the variable (userName) which will display the input value.
            Console.WriteLine("Hello, " + userName);

            Console.WriteLine("Would you like to play? (Y/N)");

            // and we'll call functions.mainFunctions.MainFuncionEntry();
        }
    }
}