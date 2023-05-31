
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    internal class UIMessages
    {
        internal const string k_ToContinueMessage = "To Continue Press the [Enter] key.";

        internal const string k_ProgramTitle = "GARAGE MANAGEMENT SYSTEM";
        internal const string k_WelcomeMessage = "Welcome to the Garage management system!";
        internal const string k_BackSignalMessage = "Hit \"B\" at any stage to go back to the main menu.";

        internal const string k_MainMenuTitle = "MAIN MENU";
        internal const string k_RegisterNewVehicleTitle = "REGISTER NEW VEHICLE";
        internal const string k_ShowVehicleListTitle = "VEHICLE LIST";
        internal const string k_ModifyVehicelStatusTitle = "VEHICLE STATUS";
        internal const string k_InflateTiresTitle = "INFLATE TIRES";
        internal const string k_FuelVehicleTitle = "FUEL VEHICLE";
        internal const string k_ChargeBatteryTitle = "CHARGE BATTERY";
        internal const string k_VehicleDetailsTitle = "VEHICLE DETAILS";

        internal const string k_ActionListHeaderRequest = "Please choose your desired action by entering the corresponding number:";

        internal const string k_LicensePlateRequest = "Please enter car License Plate:";
        internal const string k_VehicleTypeRequest = "Please enter vehicle type by entering the corresponding number:";
        internal const string k_MultiChoiceRequest = "Please choose by entering the corresponding number:";

        internal const string k_VehicleDetailRequestMultiChoice = "Please enter{0} by entering the corresponding number:";
        internal const string k_VehicleDetailRequest = "Please enter{0}:";

        internal const string k_VehicleExistsMessage = "Vehicle is already in the system.";
        internal const string k_VehicleAddedMessage = "Your vehicel has been added to the system succefully.";

        internal const string k_FilterByStatusMessage = "To filter the vehicle list please choose list filtering:";
        internal const string k_NoFilterOption = "   [0]  No filter";
        internal const string k_VehicleListEmptyMessage = "No Vehicles exist in the system!";

        internal const string k_SetVehicleStatusRequest = "Please choose the status to set the given vehicle to by entering the corresponding number:";

        internal const string k_FuelVehicleTypeRequest = "Please choose the fuel to fill vehicle with by entering the corresponding number:";
        internal const string k_NumOfLitersToFuelRequest = "Please enter amount of liters to fuel:";

        internal const string k_InflateTiresChoiceRequest = "Please choose how you would like to inflate the tires:";
        internal const string k_SpecifiedAirPressureRequest = "Please enter air pressure to inflate to all tires:";

        internal const string k_NumOfMinutesToChargeRequest = "Please enter the number of minutes to charge:";

        internal const string k_ActionSuccesful = "Action succesfully executed.";
        internal const string k_RedirectionToMainScreen = "You will now be redirected to the main page";

        internal const string k_GoodbyeMessage = "SAD TO SEE YOU GO!";

        internal const string k_CorrespondingNumberMessage = "by entering the corresponding number:";
        internal const string k_ExceptionMessage = "{0}, hit enter to try again!";

        internal const string k_FormatExceptionNumParse = "Input entered is not a valid number";
        internal const string k_ArgumentExceptionRange = "Number entered is not in the right range";



    }
}
