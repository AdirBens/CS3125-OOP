using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            runProgram();
        }

        private static void runProgram()
        {
            const int k_Height = 9;
            DisplayDiamond(k_Height);
        }

        public static void DisplayDiamond(int i_Height, char i_Symbol = '*', char i_Delimiter = ' ')
        {
            int numberOfSymbols = 1;
            int numberOfDelimiters = (i_Height - numberOfSymbols) / 2;

            recursiveDiamond(numberOfDelimiters, numberOfSymbols, i_Symbol, i_Delimiter);
        }

        private static void recursiveDiamond(int i_NumberOfDelimiters, int i_NumberOfSymbols, char i_Symbol, char i_Delimiter)
        {
            if(i_NumberOfDelimiters >= 0)
            {
                Console.WriteLine(getDiamondRow(i_NumberOfDelimiters, i_NumberOfSymbols, i_Symbol, i_Delimiter));
                recursiveDiamond(i_NumberOfDelimiters - 1, i_NumberOfSymbols + 2, i_Symbol, i_Delimiter);
                
                if(i_NumberOfDelimiters != 0)
                {
                    Console.WriteLine(getDiamondRow(i_NumberOfDelimiters, i_NumberOfSymbols, i_Symbol, i_Delimiter));
                }
            }
        }

        private static string getDiamondRow(int i_NumberOfDelimiters, int i_NumberOfSymbols, char i_Symbol, char i_Delimiter)
        {
            StringBuilder row = new StringBuilder();
            for(int i = 0; i < i_NumberOfDelimiters; i++)
            {
                row.Append(i_Delimiter);
            }

            for(int i = 0; i < i_NumberOfSymbols; i++)
            {
                row.Append(i_Symbol);
            }

            return row.ToString();
        }
    }
}
