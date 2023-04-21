﻿using System;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {

        }

        public static void GetInput(string i_DialogMessage, Func<string, bool> i_InputValidator, string i_InvalidInputMessage, out string o_UserInput)
        {
            bool inputIsValid = false;
            o_UserInput = null;

            while (!inputIsValid)
            {
                Console.WriteLine(i_DialogMessage);
                string readedInput = Console.ReadLine();

                if (i_InputValidator(readedInput))
                {
                    o_UserInput = readedInput;
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine(i_InvalidInputMessage);
                }
            }
        }

        public static bool IsPalindrome(string i_String)
        {

            return (i_String.Length < 2) || (i_String[0] == i_String[i_String.Length - 1]) && IsPalindrome(i_String.Substring(1, i_String.Length - 2));
        }

        public static bool IsDivisible(int i_Dividend, int i_Divisor)
        {
            return (i_Divisor != 0) && (i_Dividend % i_Divisor == 0);
        }

        static bool Is8DigitsBinaryNumber(string i_String)
        {
            return (i_String.Length == 8) && i_String.All(digit => digit == '0' || digit == '1');
        }
    }
}