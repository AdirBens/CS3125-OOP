
using System;
using System.Linq;

namespace Ex04.Menus.Test.TestUtils
{
    internal class VersionAndCapitalsAgent
    {
        internal static void ShowVersion()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }

        internal static void CountCapitals()
        {
            Console.WriteLine("[Count Capitals] Please enter your sentence:");
            string userSentence = Console.ReadLine();
            int numCapitals = userSentence.Count(c  => char.IsUpper(c));
            Console.WriteLine(string.Format(">> There are {0} capitals in your sentence.", 
                numCapitals));
        }
    }
}
