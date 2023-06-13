
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Events
{
    internal class ConsoleUtils
    {
        private const char k_UnderlineChar = '-';

        internal static void RenderMenu(MenuItem i_MenuItem)
        {
            StringBuilder menuBuilder = new StringBuilder();

            menuBuilder.Append(asTitle(i_MenuItem.Name));
            menuBuilder.AppendLine(buildOptionsString(i_MenuItem));

            Console.Clear();
            Console.WriteLine(menuBuilder.ToString());
        }

        internal static int GetUserSelection(MenuItem i_MenuItem)
        {
            int userSelection = 0;

            if (i_MenuItem.IsTerminal)
            {
                Console.ReadLine();
            }
            else
            {
                string backString = (i_MenuItem.ItemLevel == 0) ? "Exit" : "Back";
                int numOptions = i_MenuItem.GetChildrensIterator().Count();
                string requestString = string.Format("Enter your request: (1 to {0} or press '0' to {1}).",
                    numOptions, backString);

                userSelection = getValidInput(requestString, numOptions);
            }

            return userSelection;
        }

        private static int getValidInput(string i_RequestString, int i_Range)
        {
            bool isValid = false;
            string requestString = i_RequestString;
            int selectAsInt = -1;

            while (!isValid)
            {
                Console.WriteLine(requestString);
                Console.Write(">> ");
                string userSelect = Console.ReadLine();

                isValid = int.TryParse(userSelect, out selectAsInt);
                isValid &= selectAsInt >= 0;
                isValid &= selectAsInt <= i_Range;
                requestString = asError(i_RequestString);
            }

            return selectAsInt;
        }

        private static string asError(string i_String)
        {
            StringBuilder errorString = new StringBuilder();

            errorString.Append("[!] Invalid Input!");
            errorString.AppendLine();
            errorString.AppendLine(i_String);

            return errorString.ToString();
        }

        private static string buildOptionsString(MenuItem i_MenuItem)
        {
            StringBuilder optionsBuilder = new StringBuilder();
            int childIndex = 1;

            optionsBuilder.Append(getBoarder());
            foreach (string childItemName in i_MenuItem.GetChildrensIterator())
            {
                optionsBuilder.AppendLine(string.Format("{0} -> {1}", childIndex, childItemName));
                childIndex++;
            }

            optionsBuilder.Append(getBoarder());

            return optionsBuilder.ToString();
        }

        private static string asTitle(string i_TitleString)
        {
            StringBuilder titleBuilder = new StringBuilder();

            titleBuilder.Append(string.Format("** {0} **", i_TitleString));
            titleBuilder.AppendLine();
            titleBuilder.Append(getBoarder());

            return titleBuilder.ToString();
        }

        private static string getBoarder()
        {
            StringBuilder boarderBuilder = new StringBuilder();

            boarderBuilder.Append(k_UnderlineChar, repeatCount: 32);
            boarderBuilder.AppendLine();

            return boarderBuilder.ToString();
        }
    }
}