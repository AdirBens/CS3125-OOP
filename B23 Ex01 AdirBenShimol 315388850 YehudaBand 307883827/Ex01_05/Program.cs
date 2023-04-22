//TODO: import Ex01_01.GetInput(string i_DialogMessage, Func i_InputValidator, out o_UserInput)
using static Ex01_01.Program;
using System;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            RunProgram();
        }

        static void RunProgram()
        {
            const string v_DialogMessage = "Please enter a 6 digit number and hit enter :";
            string string v_InvalidInputMessage = "Invalid input! Please enter a 6 digit number with no letters or symbols."
            string userInput;

            GetInput(v_DialogMessage, IsNDigitsNumber, v_InvalidInputMessage, out userInput);
            PrintStatistics(userInput);
        }

        static bool IsNDigitsNumber(string i_InputNumber, int i_NumberOfDigits)
        {
            //Use int.TryParse
        }

        static int GetRightmostDigit(int[] i_InputNumberArray)
        {

        }

        static int GetLowestDigit(int[] i_InputNumberArray)
        {

        }

        static float GetDigitAverage(int[] i_InputNumberArray)
        {

        }








    }
}
