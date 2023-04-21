using System;
using System.Linq;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("123 is : " + IsDigitsStrictlyDecrease(123));
            Console.WriteLine("423 is : " + IsDigitsStrictlyDecrease(423));
            Console.WriteLine("422 is : " + IsDigitsStrictlyDecrease(422));
            Console.WriteLine("421 is : " + IsDigitsStrictlyDecrease(421));
            Console.WriteLine("0 is : " + IsDigitsStrictlyDecrease(0));
            Console.WriteLine("1 is : " + IsDigitsStrictlyDecrease(1));
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

        static int BinaryToDecimal(string i_BinaryNumberString)
        {
            int decimalRepresentation = 0;
            int digitPosition = 0;
            int numberOfDigits = i_BinaryNumberString.Length;
            
            for (int i = numberOfDigits - 1; i >= 0; i--)
            {
                if (i_BinaryNumberString[i] == '1')
                {
                    decimalRepresentation += (int)Math.Pow(2, digitPosition);
                }
                digitPosition++;
            }
            return decimalRepresentation;
        }

        static bool IsDigitsStrictlyDecrease(int i_Number)
        {
            string numberAsString = string.Format("{0}", i_Number);
            int numberOfDigits = numberAsString.Length;
            bool isStriclyDecrease = true;

            for (int i = 1; i < numberOfDigits; i++)
            {
                isStriclyDecrease &= (numberAsString[i - 1] > numberAsString[i]);
            }

            return isStriclyDecrease;
        }
    }
}
