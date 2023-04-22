using System;
using UserInput = Ex01_01.Program;
using Diamond = Ex01_02.Program;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            //int[] height = { 4, 5, 7, 8 };
            //displayDiamondTest(height);
            runProgram();
        }

        private static void runProgram()
        {
            int diamondHeight = getDiamondHeight();
            Diamond.DisplayDiamond(diamondHeight);
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

        private static void displayDiamondTest(int[] i_HeightToTest, char i_Symbol = '*', char i_Delimiter = ' ')
        {
            foreach(int height in i_HeightToTest)
            {
                Console.WriteLine("Display Diamond for Height " + height);
                Diamond.DisplayDiamond(height, i_Symbol, i_Delimiter);
                Console.WriteLine();
            }

        }
    }
}
