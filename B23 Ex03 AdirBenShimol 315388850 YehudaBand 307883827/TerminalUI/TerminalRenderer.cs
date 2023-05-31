using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConsoleUI
{
    internal class TerminalRenderer
    {
        private const char k_HorizontalBorder = '=';
        private const char k_VerticalBorder = '|';
        private const char k_MidLineSymnol = '-';
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
            welcomeScreen.AppendLine(UIMessages.k_BackSignalMessage);

            Console.WriteLine(welcomeScreen.ToString());
        }

        internal static void renderTitle(string i_Title)
        {
            StringBuilder pageHeader = new StringBuilder();

            pageHeader.AppendLine(asTitleString(i_Title));
            pageHeader.AppendLine(asMarkedString(UIMessages.k_BackSignalMessage));
            
            Console.WriteLine(pageHeader.ToString());
        }

        internal static void renderMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        internal static void renderFilterByStatusRequest(string[] i_VehicleStatusListFromAgent)
        {
            Console.WriteLine(UIMessages.k_FilterByStatusMessage);
            renderMultiChoiceRequest(UIMessages.k_FilterByStatusRequest, i_VehicleStatusListFromAgent);
        }

        internal static void renderShowVehicleList(List<string> filteredList)
        {
            StringBuilder vehicleList = new StringBuilder();
            foreach (string vehicleLicensePlate in filteredList)
            {
                vehicleList.AppendLine(vehicleLicensePlate);
            }
            Console.WriteLine(vehicleList.ToString());
        }

        internal static void renderInflateTiresRequest()
        {
            string[] tireInflationOptions = typeof(TerminalUserInterface.eTireInflationOptions).GetEnumNames();

            renderMultiChoiceRequest(UIMessages.k_InflateTiresChoiceRequest, tireInflationOptions);
        }

        internal static void renderVehicleDetails(Dictionary<string, string> i_VehicleDetails)
        {
            const int k_IndentationCount = 25;
            StringBuilder vehicleDetailsBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> vehicleProperty in i_VehicleDetails)
            {
                string property = parsePropertyToDisplayedProperty(vehicleProperty.Key);
                    vehicleDetailsBuilder.Append(property);
                    vehicleDetailsBuilder.Append(k_MidLineSymnol, repeatCount: k_IndentationCount - property.Length);
                if (property == "wheels")
                {
                    //int numOfWheels = vehicleProperty; MISIIIINGGGGG
                    vehicleDetailsBuilder.AppendLine(string.Format(""));

                }
                else
                {
                    vehicleDetailsBuilder.AppendLine(vehicleProperty.Value);
                }
            }
            Console.WriteLine(vehicleDetailsBuilder.ToString());
        }

        internal static void renderMessageAndRedirect(string i_Message)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.AppendLine(i_Message);
            messageBuilder.Append(UIMessages.k_RedirectionToMainScreen);

            Console.WriteLine(messageBuilder.ToString());
        }

        internal static void renderSuccsfulActionMessage()
        {
            renderMessageAndRedirect(UIMessages.k_ActionSuccesful);
            TerminalRenderer.renderToContinueMessage();
        }

        internal static void renderMultiChoiceRequest(string i_ChoiceHeader, string[] i_ChoiceArray)
        {
            StringBuilder choiceRequest = new StringBuilder();

            choiceRequest.AppendLine(asActionString(i_ChoiceHeader));
            choiceRequest.Append(convertChoiceArrayToDisplay(i_ChoiceArray));

            Console.WriteLine(choiceRequest.ToString());
        }

        internal static void renderEndProgramScreen()
        {
            Console.WriteLine(UIMessages.k_GoodbyeMessage);
            Console.ReadLine();
        }

        internal static void renderToContinueMessage()
        {
            Console.WriteLine(asActionString(UIMessages.k_ToContinueMessage));
            Console.ReadLine();

        }

        internal static void renderExceptionMessage(string i_Message)
        {
            Console.WriteLine(string.Format(asWarningString(UIMessages.k_ExceptionMessage), i_Message));
            Console.ReadLine();
        }

        private static string convertChoiceArrayToDisplay(string[] i_ChoiceList)
        {
            StringBuilder listToDisplay = new StringBuilder();

            for (int i = 1; i < i_ChoiceList.Length; i++)
            {
                string choice = parsePropertyToDisplayedProperty(i_ChoiceList[i]);
                listToDisplay.AppendLine(string.Format($"   [{i}] {choice}"));
            }

            return listToDisplay.ToString();
        }

        internal static List<string> convertStringListToDisplayList(List<string> i_StringList)
        {
            List<string> displayList = new List<string>();

            foreach (string str in i_StringList)
            {
                displayList.Add(parsePropertyToDisplayedProperty(str));
            }

            return displayList;
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

        internal static string parsePropertyToDisplayedProperty(string i_Property)
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
    }
}