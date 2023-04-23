using UserInput = Ex01_01.Program;
using Diamond = Ex01_02.Program;
using System;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            runProgram();
            Console.WriteLine("Press ENTER to exit ...");
            Console.ReadLine();
        }

        private static void runProgram()
        {
            int diamondHeight = getDiamondHeight();
            const char k_Symbol = '*';
            const char k_Delimiter = ' ';

            Diamond.DisplayDiamond(diamondHeight, k_Symbol, k_Delimiter);
        }

        private static int getDiamondHeight()
        {
            const string k_DialogMessage = "Insert Diamond Height (As Positive Integer)...";
            const string k_InvalidInputMessage = "Invalid Input! Expects a positive integer.";
            string inputHeight = UserInput.GetInputLine(k_DialogMessage, isPositiveInteger, k_InvalidInputMessage);

            return int.Parse(inputHeight);
        }

        private static bool isPositiveInteger(string i_String)
        {
            bool isInteger = int.TryParse(i_String, out int parsedInt);
            
            return isInteger && parsedInt > 0;
        }
    }
}
