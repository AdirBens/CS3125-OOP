using static GarageLogic.GarageAgent;
using System;
using System.Collections.Generic;
using TerminalUI;
using GarageLogic;

namespace ConsoleUI
{
    internal class TerminalUserInterface
    {
        private const string k_BackSignalFromUser = "B";

        internal void RunProgram()
        {
            eUserAction userAction = eUserAction.Empty;
            displayStartUpScreen();

            while (userAction != eUserAction.ExitProgram)
            {
                bool actionFinished = false;

                userAction = getUserAction();
                Console.Clear();

                while (!actionFinished)
                    try
                    {
                        switch (userAction)
                        {
                            case eUserAction.RegisterNewVehicle:
                                registerNewVehicle();
                                break;
                            case eUserAction.ShowVehicleList:
                                showVehicleList();
                                break;
                            case eUserAction.ChangeVehicleStatus:
                                modifyVehicleStatus();
                                break;
                            case eUserAction.InfalteTires:
                                inflateTires();
                                break;
                            case eUserAction.FillFuel:
                                fuelVehicle();
                                break;
                            case eUserAction.ChargeBattery:
                                chargeBattery();
                                break;
                            case eUserAction.ShowVehicleDetails:
                                showVehicleDetails();
                                break;
                            case eUserAction.ExitProgram:
                                TerminalRenderer.renderEndProgramScreen();
                                break;
                        }
                        actionFinished = true;
                    }
                    catch (FormatException ex)
                    {
                        TerminalRenderer.renderExceptionMessage(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        TerminalRenderer.renderExceptionMessage(ex.Message);
                    }
                    catch (BackSignalRaiseException ex)
                    {
                        actionFinished = true;
                    }
                    finally
                    {
                        Console.Clear();
                    }
            }
        }

        private eUserAction getUserAction()
        {
            while (true)
            {
                try
                {
                    bool isParseSuccessful;
                    TerminalRenderer.renderTitle(UIMessages.k_MainMenuTitle);
                    TerminalRenderer.renderChooseActionRequest();

                    isParseSuccessful = int.TryParse(readInputLine(""), out int userNumChoice);
                    validateInput(userNumChoice, typeof(eUserAction), isParseSuccessful);

                    eUserAction initialAction = (eUserAction)userNumChoice;

                    return initialAction;
                }
                catch (FormatException ex)
                {
                    TerminalRenderer.renderExceptionMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    TerminalRenderer.renderExceptionMessage(ex.Message);
                }
            }
        }

        private void registerNewVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_RegisterNewVehicleTitle);
            string vehicleType;
            string licensePlate = getLicensePlateFromUser();

            bool isVehicleInSystem = GarageAgent.LookUpLicensePlate(licensePlate);

            if (!isVehicleInSystem)
            {
                TerminalRenderer.renderEnterVehicleTypeRequest(GarageAgent.GetSupportedVehicleTypes());
                vehicleType = readInputLine("");
                int.TryParse(vehicleType, out int vehicleTypeID);


                Dictionary<string, string[]> missingDetails = GarageAgent.GetRequireadDetails(licensePlate, vehicleTypeID);
                Dictionary<string, string> detailsForAgent;

                detailsForAgent = getMissingDetailsFromUser(missingDetails);
                GarageAgent.SetRequireadDetails(detailsForAgent);

                TerminalRenderer.renderVehicleAddedSuccefullyMessage();
            }
            else
            {
                Console.WriteLine(UIMessages.k_VehicleExistsMessage);
                GarageAgent.UpdateVehicleStatus(licensePlate, "repair"); ////////////////// HANDLE THIS FUCKING SHIIIIT
            }

            TerminalRenderer.renderToContinueMessage();
        }

        private Dictionary<string, string> getMissingDetailsFromUser(Dictionary<string, string[]> i_MissingDetails)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string[]> missingDetail in i_MissingDetails)
            {
                string missingDetailToDisplay = TerminalRenderer.parsePropertyToDisplayedProperty(missingDetail.Key);
                string detailRequest = string.Format(UIMessages.k_VehicleDetailRequest, missingDetailToDisplay);

                if (missingDetail.Value != null)
                {
                    TerminalRenderer.renderMultiChoiceRequest(detailRequest, missingDetail.Value);
                }
                else
                {
                    TerminalRenderer.renderOpenRequest(detailRequest);
                }

                string missingDetailValue = readInputLine("");

                vehicleDetails.Add(missingDetail.Key, missingDetailValue);
            }

            return vehicleDetails;
        }

        private void showVehicleList()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ShowVehicleListTitle);
            TerminalRenderer.renderFilterByStatusRequest(GarageAgent.GetVehicleStatusTypes());

            string vehicleStatusAsNum = readInputLine("");

            List<string> filteredList = GarageAgent.GetVehiclesByStatus(vehicleStatusAsNum);

            TerminalRenderer.renderShowVehicleList(filteredList);
        }

        private void modifyVehicleStatus()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ModifyVehicelStatusTitle);

            string vehicleStatusAsNumber;
            string licensePlate = getLicensePlateFromUser();

            string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();

            TerminalRenderer.renderSetVehicleStatusRequest(vehicleStatusTypes);
            vehicleStatusAsNumber = readInputLine("");

            GarageAgent.UpdateVehicleStatus(licensePlate, vehicleStatusAsNumber);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private string getLicensePlateFromUser()
        {
            string enterLicensePlateMessage = TerminalRenderer.asActionString(UIMessages.k_LicensePlateRequest);
            return readInputLine(enterLicensePlateMessage);
        }

        private void inflateTires()
        {
            TerminalRenderer.renderTitle(UIMessages.k_InflateTiresTitle);

            string licensePlate = getLicensePlateFromUser();

            TerminalRenderer.renderInflateTiresRequest();

            bool isParseSuccessful = int.TryParse(readInputLine(""), out int userNumChoice);
            validateInput(userNumChoice, typeof(eTireInflationOptions), isParseSuccessful);

            eTireInflationOptions chosenInflationOption = (eTireInflationOptions)userNumChoice;

            switch (chosenInflationOption)
            {
                case (eTireInflationOptions.InflateAllToMaxCapacity):
                    ///DELETE PSI 0
                    GarageAgent.InflateTires(licensePlate, "0");
                    break;
                case (eTireInflationOptions.InflateAllToGivenAirPressure):
                    string PSIToFill;
                    PSIToFill = readInputLine(UIMessages.k_SpecifiedPSIRequest);

                    GarageAgent.InflateTires(licensePlate, PSIToFill);
                    break;
            }
            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void fuelVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_FuelVehicleTitle);

            string fuelTypeAsNumber;
            string licensePlate = getLicensePlateFromUser();

            string[] fuelTypes = GarageAgent.GetFuelTypes();

            TerminalRenderer.renderFuelTypeRequest(fuelTypes);
            fuelTypeAsNumber = readInputLine("");

            string numOfLiters = readInputLine(TerminalRenderer.asActionString(UIMessages.k_NumOfLitersToFuelRequest));

            GarageAgent.ReFuel(licensePlate, fuelTypeAsNumber, numOfLiters);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void chargeBattery()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ChargeBatteryTitle);

            string chargingDuration;
            string licensePlate = getLicensePlateFromUser();

            string numOfMinutesToChargeRequest = TerminalRenderer.asActionString(UIMessages.k_NumOfMinutesToChargeRequest);
            chargingDuration = readInputLine(numOfMinutesToChargeRequest);

            GarageAgent.ReChargeBattery(licensePlate, chargingDuration);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void showVehicleDetails()
        {
            TerminalRenderer.renderTitle(UIMessages.k_VehicleDetailsTitle);

            string licensePlate = getLicensePlateFromUser();

            Dictionary<string, string> vehicleDetails = GarageAgent.GetVehicleProfile(licensePlate);

            TerminalRenderer.renderVehicleDetails(vehicleDetails);
            TerminalRenderer.renderToContinueMessage();
        }

        private void displayStartUpScreen()
        {
            TerminalRenderer.renderStartUpScreen();
            TerminalRenderer.renderToContinueMessage();

            Console.Clear();
        }

        private static void validateInput(int userNumChoice, Type typeOfEnum, bool isParseSuccessful)
        {
            if (!isParseSuccessful)
            {
                throw new FormatException(UIMessages.k_FormatExceptionInt);
            }
            else if (userNumChoice <= 0 || userNumChoice >= Enum.GetValues(typeOfEnum).Length)
            {
                throw new ArgumentException(UIMessages.k_ArgumentExceptionRange);
            }
        }

        private string readInputLine(string i_MessageDialog)
        {
            TerminalRenderer.renderUserInputRequestMessage(i_MessageDialog);
            string userInput = Console.ReadLine();

            if (userInput.Equals(k_BackSignalFromUser) == true)
            {
                throw new BackSignalRaiseException();
            }

            return userInput;
        }

        public enum eUserAction
        {
            Empty = 0,
            RegisterNewVehicle = 1,
            ShowVehicleList = 2,
            ChangeVehicleStatus = 3,
            InfalteTires = 4,
            FillFuel = 5,
            ChargeBattery = 6,
            ShowVehicleDetails = 7,
            ExitProgram = 8
        }

        public enum eTireInflationOptions
        {
            Empty = 0,
            InflateAllToMaxCapacity = 1,
            InflateAllToGivenAirPressure = 2
        }
    }
}
