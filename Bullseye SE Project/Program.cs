using System;

namespace Bullseye_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Bullseye_Project.functions.mainFunctions.MainFuncionEntry();
            functions.mainFunctions.HowCloseThread();
            Introduction();
        }

        static void Introduction()
        {
            // we'll welcome the user here, and ask them are you ready to play or something
            // and we'll call functions.mainFunctions.MainFuncionEntry();
        }
    }
}