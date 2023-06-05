using System;
using System.Text;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class TerminalRenderer
    {
        private const char k_HorizontalBorder = '=';
        private const char k_EmptySymbol = ' ';
        private const string k_ActionSymbol = "[>] ";
        private const string k_WarningSymbol = "[Invalid!] ";

        internal static void RenderStartUpScreen()
        {
            StringBuilder welcomeScreen = new StringBuilder();

            welcomeScreen.AppendLine(asTitleString(UIMessages.k_ProgramTitle));
            welcomeScreen.AppendLine(UIMessages.k_WelcomeMessage);

            Console.WriteLine(welcomeScreen.ToString());
        }

        internal static void RenderTitle(string i_Title)
        {
            StringBuilder pageHeader = new StringBuilder();

            pageHeader.Append(asTitleString(i_Title));
            pageHeader.AppendLine(UIMessages.k_BackSignalMessage);


            Console.WriteLine(pageHeader.ToString());
        }

        internal static void RenderMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal static void RenderFilterByStatusRequest(string[] i_VehicleStatusListFromAgent)
        {
            StringBuilder filterRequest = new StringBuilder();
            
            filterRequest.AppendLine(UIMessages.k_FilterByStatusMessage);
            filterRequest.AppendLine(UIMessages.k_NoFilterOption);
            filterRequest.Append(convertChoiceArrayToDisplay(i_VehicleStatusListFromAgent));
            
            Console.WriteLine(filterRequest.ToString());
        }

        internal static void RenderShowVehicleList(List<string> i_FilteredList)
        {
            StringBuilder vehicleList = new StringBuilder();
            vehicleList.AppendLine(UIMessages.k_VehicleListHeader);
            for (int i = 0; i < i_FilteredList.Count; i++)
            {
                vehicleList.AppendLine(string.Format(UIMessages.k_VehicleRecordLine, i + 1, i_FilteredList[i]));
            }
            Console.WriteLine(vehicleList.ToString());
        }

        internal static void RenderVehicleDetails(string i_VehicleDetails, string i_LicensePlate)
        {
            StringBuilder vehicleDetailsBuilder = new StringBuilder();
            vehicleDetailsBuilder.AppendLine(asTitleString(string.Format(UIMessages.k_VehicleDetailsPresentedTitle, i_LicensePlate)));
            vehicleDetailsBuilder.AppendLine(i_VehicleDetails);

            Console.WriteLine(vehicleDetailsBuilder.ToString());
        }

        internal static void RenderMessageAndRedirect(string i_Message)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.AppendLine(i_Message);
            messageBuilder.Append(UIMessages.k_RedirectionToMainScreen);

            Console.WriteLine(messageBuilder.ToString());
            RenderToContinueMessage();
        }

        internal static void RenderSuccsfulActionMessage()
        {
            RenderMessageAndRedirect(UIMessages.k_ActionSuccesful);
        }

        internal static void RenderMultiChoiceRequest (string[] i_ChoiceArray, string i_ChoiceHeader = null)
        {
            StringBuilder choiceRequest = new StringBuilder();

            choiceRequest.AppendLine(AsActionString(i_ChoiceHeader));
            choiceRequest.Append(convertChoiceArrayToDisplay(i_ChoiceArray));

            Console.WriteLine(choiceRequest.ToString());
        }

        internal static void RenderEndProgramScreen()
        {
            
            Console.WriteLine(asTitleString(UIMessages.k_GoodbyeMessage));
            RenderToContinueMessage();
        }

        internal static void RenderToContinueMessage()
        {
            Console.WriteLine();
            Console.WriteLine(AsActionString(UIMessages.k_ToContinueMessage));
            Console.ReadLine();

        }

        internal static void RenderExceptionMessage(string i_ExceptionMessage)
        {
            Console.WriteLine(AsWarningString(i_ExceptionMessage));
            Console.ReadLine();
        }

        internal static string AsActionString(string i_Message)
        {
            return k_ActionSymbol + i_Message;
        }

        internal static string AsWarningString(string i_Message)
        {
            return k_WarningSymbol + i_Message;
        }

        internal static string ParsePropertyToDisplayedProperty(string i_Property)
        {
            string withoutPrefix = i_Property.Replace("m_", string.Empty).Replace(".", string.Empty);

            StringBuilder newString = new StringBuilder();
            foreach (char character in withoutPrefix)
            {
                if (char.IsUpper(character))
                {
                    newString.Append(' ');
                }

                newString.Append(character);
            }

            return newString.ToString();
        }

        private static string asTitleString(string i_String)
        {
            int consoleWidth = Console.WindowWidth;
            StringBuilder titledString = new StringBuilder();

            titledString.Append(k_HorizontalBorder, repeatCount: consoleWidth);
            titledString.AppendLine();
            titledString.Append(k_EmptySymbol, repeatCount: (consoleWidth - i_String.Length)/2);
            titledString.Append(i_String);
            titledString.AppendLine();
            titledString.Append(k_HorizontalBorder, repeatCount: consoleWidth);

            return titledString.ToString();
        }
        private static string convertChoiceArrayToDisplay(string[] i_ChoiceList)
        {
            StringBuilder listToDisplay = new StringBuilder();

            for (int i = 1; i < i_ChoiceList.Length; i++)
            {
                string choice = ParsePropertyToDisplayedProperty(i_ChoiceList[i]);
                listToDisplay.AppendLine(string.Format($"   [{i}] {choice}"));
            }

            return listToDisplay.ToString();
        }
    }
}