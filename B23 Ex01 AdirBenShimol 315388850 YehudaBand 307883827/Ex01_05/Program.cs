using System;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            runProgram();
        }

        static void runProgram()
        {
            const string k_DialogMessage = "Please enter a 6 digit number and hit enter :";
            const string k_InvalidInputMessage = "Invalid input! Please enter a 6 digit number with no letters or symbols.";

            Ex01_01.Program.GetInputLine(k_DialogMessage, stringIsSixDigitsNumber, k_InvalidInputMessage, out string userInput);
            printStatistics(userInput);
        }

        static bool stringIsSixDigitsNumber(string i_UserInput)
        {
            return (Ex01_04.Program.StringIsLengthSix(i_UserInput) && Ex01_04.Program.StringIsNumber(i_UserInput));
        }

        static void printStatistics(string i_UserInput)
        { 
            Console.WriteLine(string.Format("The number you chose is: {0}", i_UserInput));
            Console.WriteLine(string.Format("{0} digits from the number are greater than the rightmost digit.", 
                getNumberOfDigitsLargerThanRightmostDigit(i_UserInput)));
            Console.WriteLine(string.Format("The smallest digit in the number is: {0}", getLowestDigit(i_UserInput)));
            Console.WriteLine(string.Format("The average of all digits is: {0}", getDigitAverage(i_UserInput)));   
            Console.WriteLine("Hit ENTER to end the program...");
            Console.ReadLine();
        }

        static int getNumberOfDigitsLargerThanRightmostDigit(string i_UserInput)
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

        static char getLowestDigit(string i_UserInput)
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

        static float getDigitAverage(string i_userInput)
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
