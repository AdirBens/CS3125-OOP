
using System.Text;
using System;

namespace ConsoleUI
{
    internal class TerminalRenderer
    {
        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';
        private const char k_EmptySymbol = ' ';
        private const char k_LeftMarkSymbol = '(';
        private const char k_RightMarkSymbol = ')';
        private const string k_BulletSymbol = "[*] ";
        private const string k_ActionSymbol = "[>] ";
        private const string k_WarningSymbol = "[Invalid!] ";
        internal static void renderStartUpScreen()
        {
            StringBuilder welcomeScreen = new StringBuilder();
            welcomeScreen.AppendLine(asTitleString(UIMessages.k_ProgramTitle));
            welcomeScreen.AppendLine(UIMessages.k_WelcomeMessage);
            Console.WriteLine(welcomeScreen.ToString());

        }

        internal static void renderInitialActionScreen()
        {
            StringBuilder initialAction = new StringBuilder();  
            initialAction.AppendLine(UIMessages.k_ActionListHeader);
            initialAction.AppendLine(UIMessages.k_InitialActionList);
            Console.WriteLine(initialAction.ToString());
        }

        internal static void renderSpecifiedVehicleActionScreen()
        {
            StringBuilder specifiedVehicle = new StringBuilder();
            specifiedVehicle.AppendLine(UIMessages.k_ActionListHeader);
            specifiedVehicle.AppendLine(UIMessages.k_SpecifiedVehicleActionList);
        }


        internal static void renderEndProgramScreen()
        {

        }

        internal static void renderToContinueMessage(string i_MessageDialog)
        {
            Console.WriteLine(asActionString(UIMessages.k_ToContinueMessage));

        }

        internal static void renderUserInputRequestMessage(string i_MessageDialog)
        {
            StringBuilder message = new StringBuilder();

            message.Append(i_MessageDialog);
            Console.WriteLine(message.ToString());
        }

        internal static string asActionString(string i_Message)
        {
            return k_ActionSymbol + i_Message;
        }

        internal static string asWarningString(string i_Message)
        {
            return k_WarningSymbol + i_Message;
        }

        internal static string asMarkedString(string i_String)
        {
            StringBuilder markedString = new StringBuilder();

            markedString.Append(k_LeftMarkSymbol);
            markedString.Append(i_String);
            markedString.Append(k_RightMarkSymbol);

            return markedString.ToString();
        }

        internal static string asTitleString(string i_String, int i_Indentation = 12)
        {
            int indentation = i_Indentation;
            StringBuilder titledString = new StringBuilder();

            titledString.Append(k_HorizontalBorder, repeatCount: (2 * indentation) + i_String.Length);
            titledString.AppendLine();
            titledString.Append(k_EmptySymbol, repeatCount: indentation);
            titledString.Append(i_String);
            titledString.AppendLine();
            titledString.Append(k_HorizontalBorder, repeatCount: (2 * indentation) + i_String.Length);
            titledString.AppendLine();

            return titledString.ToString();
        }

    }
}
