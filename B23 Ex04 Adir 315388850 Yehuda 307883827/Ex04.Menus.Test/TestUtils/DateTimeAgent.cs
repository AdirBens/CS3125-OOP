
using System;

namespace Ex04.Menus.Test.TestUtils
{
    internal class DateTimeAgent
    {
        internal static void ShowDate()
        {
            Console.WriteLine(string.Format("Today is: {0}", 
                DateTime.Now.ToString("dd MMMM yyyy")));
        }

        internal static void ShowTime() { 
            Console.WriteLine(string.Format("Now is: {0}", 
                DateTime.Now.ToString("HH:mm:ss")));
        }
    }
}
