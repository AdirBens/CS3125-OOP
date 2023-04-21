using System;
using static Ex01_01.Program;

namespace Ex01_04
{
    class Program
    {
        static void Main()
        {
            RunProgram();
        }

        static void RunProgram()
        {
            const string v_DialogMessage = "Please enter a 6 charectar word or a 6 digit number :";
            const string v_InvalidInputMessage = "Invalid input! Please enter an 'only digit' or 'only lettters' sequence of exactly 6 characters";
            string UserInput;
            GetInput(v_DialogMessage, CheckConditionsOnString, v_InvalidInputMessage, out UserInput);
            PrintStatistics(UserInput);
        }

        static bool StringIsWord(string i_InputString)
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

        static bool StringIsLengthSix(string i_InputString)
        {
            return i_InputString.Length == 6;
        }
        
        static bool StringIsNumber(string i_InputString)
        {
            bool stringIsNumber = true;
            foreach (char c in i_InputString)
            {
                if (!char.IsDigit(c))
                {
                    stringIsNumber = false;
                }
            }
            return stringIsNumber;
        }

        static int CountUppercase(string i_InputString)
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

        static bool CheckConditionsOnString(string i_InputString)
        {
            return (StringIsWord(i_InputString) || StringIsNumber(i_InputString)) && StringIsLengthSix(i_InputString);
        }

        static void PrintStatistics(string i_InputString)
        {
            bool isPalyndrome = IsPalindrome(i_InputString);
            bool isDivisibleByThree;
            int numberOfUppercaseLetters;
            Console.WriteLine(string.Format("The sequence you chose is: {0}", i_InputString));
            Console.WriteLine(string.Format("The sequence {0} a palyndrome.", MessageConditionBuilder(isPalyndrome)));
            if (StringIsNumber(i_InputString))
            {
                isDivisibleByThree = IsDivisible(int.Parse(i_InputString), 3);
                Console.WriteLine(string.Format("The number {0} divisible by three.", MessageConditionBuilder(isDivisibleByThree)));
            }
            else
            {
                numberOfUppercaseLetters = CountUppercase(i_InputString);
                Console.WriteLine(string.Format("The number of uppercase letters is: {0}", numberOfUppercaseLetters));
            }

            Console.WriteLine("Hit ENTER to end the program...");
            Console.ReadLine();
        }

        static string MessageConditionBuilder(bool i_Condition)
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
