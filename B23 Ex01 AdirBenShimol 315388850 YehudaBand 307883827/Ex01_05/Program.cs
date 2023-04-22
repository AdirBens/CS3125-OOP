//TODO: Decide if we want to use the 'using static...' or not?
//TODO: Decide if we want to manipulate chars or turn digits in to ints?
using static Ex01_01.Program;
using static Ex01_04.Program;
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
            const string v_InvalidInputMessage = "Invalid input! Please enter a 6 digit number with no letters or symbols.";

            GetInput(v_DialogMessage, StringIsSixDigitsNumber, v_InvalidInputMessage, out string userInput);
            PrintStatistics(userInput);
        }

        static bool StringIsSixDigitsNumber(string i_UserInput)
        {
            return (StringIsLengthSix(i_UserInput) && StringIsNumber(i_UserInput));
        }

        static void PrintStatistics(string i_UserInput)
        { 
            Console.WriteLine(string.Format("The number you chose is: {0}", i_UserInput));
            Console.WriteLine(string.Format("{0} digits from the number are greater than the rightmost digit.", 
                GetNumberOfDigitsLargerThanRightmostDigit(i_UserInput)));
            Console.WriteLine(string.Format("The smallest digit in the number is: {0}", GetLowestDigit(i_UserInput)));
            Console.WriteLine(string.Format("The average of all digits is: {0}", GetDigitAverage(i_UserInput)));   
            Console.WriteLine("Hit ENTER to end the program...");
            Console.ReadLine();
        }

        static int GetNumberOfDigitsLargerThanRightmostDigit(string i_UserInput)
        {
            int rightmostDigit = i_UserInput[i_UserInput.Length - 1];
            int numberOfLargerThanRightmostDigit = 0;
            foreach(char c in i_UserInput)
            {
                if (c > rightmostDigit)
                {
                    numberOfLargerThanRightmostDigit++;
                }
            }
            return numberOfLargerThanRightmostDigit;
        }

        static char GetLowestDigit(string i_UserInput)
        {
            char smallestDigit = i_UserInput[0];
            foreach(char c in i_UserInput)
            {
                if (c < smallestDigit)
                {
                    smallestDigit = c;
                }
            }
            return smallestDigit;
        }

        static float GetDigitAverage(string i_userInput)
        {
            float sumOfDigits = 0;
            foreach(char c in i_userInput)
            {
                int digitValue = c - '0';
                sumOfDigits += digitValue;
            }
            float averageOfDigits = sumOfDigits / i_userInput.Length;
            return averageOfDigits; 
        }
    }
}
