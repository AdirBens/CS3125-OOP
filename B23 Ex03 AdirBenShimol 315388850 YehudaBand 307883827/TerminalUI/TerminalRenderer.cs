
using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        internal static void renderChooseActionRequest()
        {
            List<string> actionChoices = convertEnumToList<TerminalUserInterface.eUserAction>();

            renderMultiChoiceRequest(UIMessages.k_ActionListHeaderRequest, actionChoices);
        }

        internal static void renderEnterLicensePlateRequest()
        {
            Console.WriteLine(asActionString(UIMessages.k_LicensePlateRequest));

        }

        internal static void renderEnterVehicleTypeRequest(List<string> i_VehicleListFromAgent)
        {
            renderMultiChoiceRequest(UIMessages.k_VehicleTypeRequest, i_VehicleListFromAgent);
        }

        internal static void renderVehicleAddedSuccefullyMessage()
        {
            StringBuilder vehicleAdded = new StringBuilder();

            vehicleAdded.AppendLine(UIMessages.k_VehicleAddedMessage);
            vehicleAdded.Append(UIMessages.k_RedirectionToMainScreen);

            Console.WriteLine(vehicleAdded.ToString());
        }

        internal static void renderVehicleAlreadyExistsMessage()
        {
            StringBuilder vehicleExists = new StringBuilder();

            vehicleExists.AppendLine(UIMessages.k_VehicleExistsMessage);
            vehicleExists.Append(UIMessages.k_RedirectionToMainScreen);

            Console.WriteLine(vehicleExists.ToString());
        }

        internal static void renderFilterByStatusRequest(List<string> i_VehicleStatusListFromAgent)
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

        internal static void renderSetVehicleStatusRequest(List<string> i_VehicleTypeListFromAgent)
        {
            renderMultiChoiceRequest(UIMessages.k_SetVehicleStatusRequest, i_VehicleTypeListFromAgent);
        }

        internal static void renderInflateTiresRequest()
        {
            List<string> tireInflationOptions = convertEnumToList<TerminalUserInterface.eTireInflationOptions>();

            renderMultiChoiceRequest(UIMessages.k_InflateTiresChoiceRequest, tireInflationOptions);
        }

        internal static void renderFuelTypeRequest(List<string> i_FuelTypeListFromAgent)
        {
            renderMultiChoiceRequest(UIMessages.k_FuelVehicleTypeRequest, i_FuelTypeListFromAgent);
        }

        internal static void renderVehicleDetails(Dictionary<string, string> i_VehicleDetails)
        {
            const int k_IndentationCount = 25;
            StringBuilder vehicleDetailsBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> vehicleProperty in i_VehicleDetails)
            {
                string property = parsePropertyToDisplayedProperty(vehicleProperty.Key);
                if (property == "wheels")
                {
                    //special case for wheels
                }
                else
                {
                    string value = vehicleProperty.Value;
                    vehicleDetailsBuilder.Append(property);
                    vehicleDetailsBuilder.Append(k_MidLineSymnol, repeatCount: k_IndentationCount - property.Length);
                    vehicleDetailsBuilder.AppendLine(value);
                }
            }
            Console.WriteLine(vehicleDetailsBuilder.ToString());
        }

        internal static void renderSuccsfulActionMessage()
        {
            StringBuilder succesfulAction = new StringBuilder();

            succesfulAction.AppendLine(UIMessages.k_ActionSuccesful);
            succesfulAction.Append(UIMessages.k_RedirectionToMainScreen);

            Console.WriteLine(succesfulAction.ToString());
            TerminalRenderer.renderToContinueMessage();


        }

        internal static void renderMultiChoiceRequest(string i_ChoiceHeader, List<string> i_ChoiceList)
        {
            StringBuilder choiceRequest = new StringBuilder();

            choiceRequest.AppendLine(asActionString(i_ChoiceHeader));
            choiceRequest.Append(convertChoiceList(i_ChoiceList));

            Console.WriteLine(choiceRequest.ToString());
        }

        internal static void renderOpenRequest(string i_RequestHeader)
        {
            Console.WriteLine(asActionString(i_RequestHeader));
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

        internal static void renderUserInputRequestMessage(string i_MessageDialog)
        {
            Console.WriteLine(i_MessageDialog);
        }

        internal static void renderExceptionMessage(string i_Message)
        {
            Console.WriteLine(string.Format(asWarningString(UIMessages.k_ExceptionMessage), i_Message));
            Console.ReadLine();
        }

        private static string convertChoiceList(List<string> i_ChoiceList)
        {
            StringBuilder listToDisplay = new StringBuilder();

            for (int i = 1; i < i_ChoiceList.Count; i++)
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
            string withoutPrefix = i_Property.Replace("m_", string.Empty);
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

        private static List<string> convertEnumToList<T>()
        {
            Type enumType = typeof(T);

            List<string> enumValues = new List<string>();

            foreach (T value in Enum.GetValues(enumType))
            {
                enumValues.Add(value.ToString());
            }

            return enumValues;
        }
    }
}

