using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
            Console.WriteLine("Press ENTER to exit ...");
            Console.ReadLine();
        }

        static void runProgram()
        {
            const string k_DialogMessage = "Please enter a 6 charectar word or a 6 digit number :";
            const string k_InvalidInputMessage = "Invalid input! Please enter an 'only digit' or 'only lettters' sequence of exactly 6 characters";

            string inputString = Ex01_01.Program.GetInputLine(k_DialogMessage, checkConditionsOnString, k_InvalidInputMessage);
            printStatistics(inputString);
        }

        static bool stringIsWord(string i_InputString)
        {
            bool isLetterString = true;
            foreach (char c in i_InputString)
            {
                isLetterString &= char.IsUpper(c) || char.IsLower(c);
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
            bool isPalyndrome = Ex01_01.Program.IsPalindrome(i_InputString);

            Console.WriteLine("[+] The sequence you chose is: {0}", i_InputString);
            Console.WriteLine("[+] The sequence {0} a palyndrome.", messageConditionBuilder(isPalyndrome));
            if (StringIsNumber(i_InputString))
            {
                bool isDivisibleByThree = Ex01_01.Program.IsDivisible(int.Parse(i_InputString), 3);
                Console.WriteLine("[+] The number {0} divisible by three.", messageConditionBuilder(isDivisibleByThree));
            }
            else
            {
                int numberOfUppercaseLetters = countUppercase(i_InputString);
                Console.WriteLine("[+] Number of uppercase letters is: {0}", numberOfUppercaseLetters);
            }
        }

        static string messageConditionBuilder(bool i_Condition)
        {
            return i_Condition ? "is" : "is not";
        }
    }
}
