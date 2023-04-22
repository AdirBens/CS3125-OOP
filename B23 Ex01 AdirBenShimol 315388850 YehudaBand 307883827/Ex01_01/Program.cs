using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex01_01
{
    // TODO: Linting and CleanCode checks - stick to conventions guidelines.
    public class Program
    {
        public static void Main()
        {
            runProgram();
            //runTests();
        }

        private static void runProgram()
        {
            string[] binaryNumbers = getUserInput();
            int[] decimalNumbers = binaryToDecimal(binaryNumbers);
            Dictionary<string, Func<string[], float>> binaryStatisticCheckers = loadBinaryStatisticsCheckers();
            Dictionary<string, Func<int, bool>> decimalStatisticCheckers = loadDecimalStatisticsCheckers();

            printDescendingOrder(decimalNumbers);
            Console.WriteLine(buildStatisticsReport(binaryNumbers, decimalNumbers, binaryStatisticCheckers, decimalStatisticCheckers));
        }

        private static void runTests()
        {
            Dictionary<string, Func<string[], float>> binaryStatisticCheckers = loadBinaryStatisticsCheckers();
            Dictionary<string, Func<int, bool>> decimalStatisticCheckers = loadDecimalStatisticsCheckers();
            string[][] binarySeriesTestSet = { new string[] { "01000000", "01111011", "01111001" }, 
                                               new string[] { "01010101", "11110000", "11111111" },
                                               new string[] { "00000100", "00010000", "00001111" } };

            foreach(string[] testSet in binarySeriesTestSet)
            {
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("Tested Binary Series: {0}  {1}  {2} ", testSet);
                string[] binaryNumbers = testSet;
                int[] decimalNumbers = binaryToDecimal(binaryNumbers);

                printDescendingOrder(decimalNumbers);
                Console.WriteLine(buildStatisticsReport(binaryNumbers, decimalNumbers, binaryStatisticCheckers, decimalStatisticCheckers));
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");

        }

        public static string GetInputLine(string i_DialogMessage, Func<string, bool> i_InputValidator, string i_InvalidInputMessage)
        {
            bool isValid = false;
            string userInput = "";

            while (!isValid)
            {
                Console.WriteLine(i_DialogMessage);
                string receivedInput = Console.ReadLine();

                if (i_InputValidator(receivedInput))
                {
                    userInput = receivedInput;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine(i_InvalidInputMessage);
                }
            }

            return userInput;
        }

        public static bool IsPalindrome(string i_String)
        {
            bool isVacuouslyPalindrome = i_String.Length < 2;
            bool isFirstAndLastCharEquals = !isVacuouslyPalindrome && i_String[0] == i_String[i_String.Length - 1];

            return isVacuouslyPalindrome || isFirstAndLastCharEquals && IsPalindrome(i_String.Substring(1, i_String.Length - 2));
        }

        public static bool IsPalindrome(int i_Number)
        {
            return IsPalindrome(i_Number.ToString());
        }

        public static bool IsDivisible(int i_Dividend, int i_Divisor)
        {
            return (i_Divisor != 0) && (i_Dividend % i_Divisor == 0);
        }

        private static Dictionary<string, Func<string[], float>> loadBinaryStatisticsCheckers()
        {
            Dictionary<string, Func<string[], float>> statisticsCheckers = new Dictionary<string, Func<string[], float>>();

            statisticsCheckers.Add("Average frequency of '1' digit among the given binary numbers", calculateOnesFrequency);

            return statisticsCheckers;
        }

        private static Dictionary<string, Func<int, bool>> loadDecimalStatisticsCheckers()
        {
            Dictionary<string, Func<int, bool>> statisticsCheckers = new Dictionary<string, Func<int, bool>>();
            
            statisticsCheckers.Add("Numbers that are a power of 2", isPowerOfTwo);
            statisticsCheckers.Add("Numbers that are a dived by 4", isDivisibleBy4);
            statisticsCheckers.Add("Numbers that their decimal digits constitutes a strictly-decreasing series", isDigitsStrictlyDecrease);
            statisticsCheckers.Add("Numbers that their decimal digits constitutes a Palindrome", IsPalindrome);

            return statisticsCheckers;
        }

        private static string[] getUserInput()
        {
            const int k_NumbersToRead = 3;
            const string k_DialogMessage = "Insert an 8-Digits Binary Number...";
            const string k_InvalidInputMessage = "Invalid Input! Expects an 8-Digits Binary Number.";
            string[] stringBinaryNumbers = new string[k_NumbersToRead];

            for (int i = 0; i < k_NumbersToRead; i++)
            {
                stringBinaryNumbers[i] = GetInputLine(k_DialogMessage, is8DigitsBinaryNumber, k_InvalidInputMessage);
            }

            return stringBinaryNumbers;
        }

        private static bool isDivisibleBy4(int i_Dividend)
        {
            return IsDivisible(i_Dividend, 4);
        }

        private static bool isPowerOfTwo(int i_Number)
        {
            return (i_Number & (i_Number - 1)) == 0;
        }

        private static bool isDigitsStrictlyDecrease(int i_Number)
        {
            string stringNumber = i_Number.ToString();
            int numberOfDigits = stringNumber.Length;
            bool isStrictlyDecrease = true;

            for (int i = 1; i < numberOfDigits; i++)
            {
                isStrictlyDecrease &= stringNumber[i - 1] > stringNumber[i];
            }

            return isStrictlyDecrease;
        }

        private static bool is8DigitsBinaryNumber(string i_String)
        {
            return (i_String.Length == 8) && i_String.All(digit => digit == '0' || digit == '1');
        }

        private static int binaryToDecimal(string i_BinaryNumber)
        {
            int decimalRepresentation = 0;
            int digitPosition = 0;
            int numberOfDigits = i_BinaryNumber.Length;
            
            for (int i = numberOfDigits - 1; i >= 0; i--)
            {
                if (i_BinaryNumber[i] == '1')
                {
                    decimalRepresentation += (int)Math.Pow(2, digitPosition);
                }
                digitPosition++;
            }
            return decimalRepresentation;
        }

        private static int[] binaryToDecimal(string[] i_BinaryNumbers)
        {
            int[] decimalNumbers = new int[i_BinaryNumbers.Length];

            for(int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                decimalNumbers[i] = binaryToDecimal(i_BinaryNumbers[i]);
            }

            return decimalNumbers;
        }

        private static void printDescendingOrder(int[] i_DecimalNumbers)
        {
            Array.Sort(i_DecimalNumbers, (firstNumber, secondNumber) => secondNumber.CompareTo(firstNumber));

            foreach(int number in i_DecimalNumbers)
            {
                Console.WriteLine(number);
            }
        }

        private static float calculateOnesFrequency(string[] i_BinaryNumbers)
        {
            string concatenatedBinaryNumbers = String.Join("", i_BinaryNumbers);
            int totalNumberOfDigits = concatenatedBinaryNumbers.Length;
            int numberOfOnes = concatenatedBinaryNumbers.Count(digit => digit == '1');
            
            return (float)numberOfOnes / totalNumberOfDigits;
        }

        private static string buildStatisticsReport(string[] i_BinaryNumbers, 
                                                    int[] i_DecimalNumbers, 
                                                    Dictionary<string, Func<string[], float>> i_BinaryStatisticsCheckers, 
                                                    Dictionary<string, Func<int, bool>> i_DecimalStatisticsCheckers)
        {
            StringBuilder statistics = new StringBuilder();

            foreach(KeyValuePair<string, Func<string[], float>> checker in i_BinaryStatisticsCheckers)
            {
                statistics.AppendFormat("[+] {0} : {1}", checker.Key, checker.Value(i_BinaryNumbers));
                statistics.AppendLine();
            }
            
            foreach (KeyValuePair<string, Func<int, bool>> checker in i_DecimalStatisticsCheckers)
            {
                statistics.AppendFormat("[+] {0} : {1}", checker.Key, i_DecimalNumbers.Count(checker.Value));
                statistics.AppendLine();
            }

            return statistics.ToString();
        }
    }
}