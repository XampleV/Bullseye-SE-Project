﻿using System;

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
                Console.WriteLine("What difficulty? Easy, Medium, or Hard?");
                string Difficulty = Console.ReadLine();
                if (Difficulty == ("Easy")
                    {

                }
                else if (Difficulty == ("Medium")
                    {

                }
                else (Difficulty == ("Hard")
                        {

                }
                functions.mainFunctions.MainFunctionEntry(userName, mode);
            }
            else if (Choice == "NO")
            {
                Console.WriteLine("Have a great day then!");
            }
        }
    }
}