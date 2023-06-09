﻿using System;
using System.Linq;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
            Console.WriteLine("Press ENTER to exit ...");
            Console.ReadLine();
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

        private static void runProgram()
        {
            string[] binaryNumbers = getUserInput();
            int[] decimalNumbers = binaryToDecimal(binaryNumbers);
            
            printDescendingOrder(decimalNumbers);
            Console.WriteLine(buildStatisticsReport(binaryNumbers, decimalNumbers));
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

        private static bool is8DigitsBinaryNumber(string i_String)
        {
            return (i_String.Length == 8) && i_String.All(digit => digit == '0' || digit == '1');
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

        private static string buildStatisticsReport(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
        {
            string statisticsReport = string.Format(
@"[+] Average frequency of '1' digit among the given binary numbers : {0:F2}
[+] Numbers that are a power of 2 : {1}  
[+] Numbers that are a divisible by 4 : {2}
[+] Numbers that their decimal digits constitute a strictly-decreasing series : {3}
[+] Numbers that their decimal digits constitute a Palindrome : {4}", 
                calculateOnesFrequency(i_BinaryNumbers),
                i_DecimalNumbers.Count(isPowerOfTwo),
                i_DecimalNumbers.Count(isDivisibleBy4),
                i_DecimalNumbers.Count(isDigitsStrictlyDecrease),
                i_DecimalNumbers.Count(IsPalindrome));

            return statisticsReport;
        }
    }
}