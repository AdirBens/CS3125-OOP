using System;

namespace Ex01_04
{
    public class Program
    {
        static void Main()
        {
            runProgram();
        }

        static void runProgram()
        {
            const string k_DialogMessage = "Please enter a 6 charectar word or a 6 digit number :";
            const string k_InvalidInputMessage = "Invalid input! Please enter an 'only digit' or 'only lettters' sequence of exactly 6 characters";

            Ex01_01.Program.GetInput(k_DialogMessage, checkConditionsOnString, k_InvalidInputMessage, out string UserInput);
            printStatistics(UserInput);
        }

        static bool stringIsWord(string i_InputString)
        {
            bool isLetterString = true;
            foreach (char c in i_InputString)
            {
                if (!char.IsUpper(c) && !char.IsLower(c))
                {
                    isLetterString = false;
                }
            }
            return isLetterString;
        }

        public static bool StringIsLengthSix(string i_InputString)
        {
            return i_InputString.Length == 6;
        }
        
        public static bool StringIsNumber(string i_InputString)
        {
            return int.TryParse(i_InputString, out _);
        }

        static int countUppercase(string i_InputString)
        {
            int numberOfUppercaseLetters = 0;
            foreach (char c in i_InputString)
            {
                if (char.IsUpper(c))
                {
                    numberOfUppercaseLetters++;
                }
            }
            return numberOfUppercaseLetters;
        }

        static bool checkConditionsOnString(string i_InputString)
        {
            return (stringIsWord(i_InputString) || StringIsNumber(i_InputString)) && StringIsLengthSix(i_InputString);
        }

        static void printStatistics(string i_InputString)
        {
            bool isPalyndrome = IsPalindrome(i_InputString);
            bool isDivisibleByThree;
            int numberOfUppercaseLetters;
            Console.WriteLine(string.Format("The sequence you chose is: {0}", i_InputString));
            Console.WriteLine(string.Format("The sequence {0} a palyndrome.", messageConditionBuilder(isPalyndrome)));
            if (StringIsNumber(i_InputString))
            {
                isDivisibleByThree = IsDivisible(int.Parse(i_InputString), 3);
                Console.WriteLine(string.Format("The number {0} divisible by three.", messageConditionBuilder(isDivisibleByThree)));
            }
            else
            {
                numberOfUppercaseLetters = countUppercase(i_InputString);
                Console.WriteLine(string.Format("The number of uppercase letters is: {0}", numberOfUppercaseLetters));
            }

            Console.WriteLine("Hit ENTER to end the program...");
            Console.ReadLine();
        }

        static string messageConditionBuilder(bool i_Condition)
        {
            string conditionMessage = "is not";
            if (i_Condition)
            {
                conditionMessage = "is";
            }

            return conditionMessage;
        }
    }
}
