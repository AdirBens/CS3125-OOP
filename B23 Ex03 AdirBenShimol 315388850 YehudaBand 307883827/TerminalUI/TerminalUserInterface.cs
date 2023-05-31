using System;
using System.Collections.Generic;
using TerminalUI;
using GarageLogic;
using GarageLogic.Exceptions;

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
                                break;
                        }
                        actionFinished = true;
                    }
                    catch (FormatException fe)
                    {
                        TerminalRenderer.renderExceptionMessage(fe.Message);
                    }
                    catch (ArgumentException ae)
                    {
                        TerminalRenderer.renderExceptionMessage(string.Format(UIMessages.k_ArgumentExceptionRange, ae.ParamName));
                    }
                    catch (BackSignalRaiseException)
                    {
                        actionFinished = true;
                    }
                    catch (ValueOutOfRangeException voore)
                    {
                        TerminalRenderer.renderExceptionMessage(voore.Message);
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
                    string[] actionChoices = typeof(eUserAction).GetEnumNames();

                    TerminalRenderer.renderTitle(UIMessages.k_MainMenuTitle);
                    TerminalRenderer.renderMultiChoiceRequest(actionChoices, UIMessages.k_ActionListHeaderRequest);

                    int userNumChoice = readInputAsInt();
                    validateInput(userNumChoice, typeof(eUserAction));

                    eUserAction userAction = (eUserAction)userNumChoice;

                    return userAction;
                }
                catch (FormatException ex)
                {
                    TerminalRenderer.renderExceptionMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    TerminalRenderer.renderExceptionMessage(ex.Message);
                }
                catch (BackSignalRaiseException) { }
            }
        }

        private void registerNewVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_RegisterNewVehicleTitle);
            string licensePlate = getLicensePlateFromUser();

            bool isVehicleInSystem = GarageAgent.LookUpLicensePlate(licensePlate);

            if (!isVehicleInSystem)
            {
                TerminalRenderer.renderMultiChoiceRequest(GarageAgent.GetSupportedVehicleTypes(), UIMessages.k_VehicleTypeRequest);
                int vehicleTypeID = readInputAsInt();

                Dictionary<string, string[]> missingDetails = GarageAgent.GetRequireadDetails(licensePlate, vehicleTypeID);
                Dictionary<string, string> detailsForAgent;

                detailsForAgent = getMissingDetailsFromUser(missingDetails);
                GarageAgent.SetRequireadDetails(licensePlate, detailsForAgent);

                TerminalRenderer.renderMessageAndRedirect(UIMessages.k_VehicleAddedMessage);
            }
            else
            {
                TerminalRenderer.renderMessage(UIMessages.k_VehicleExistsMessage);
                string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();
            }
        }

        private Dictionary<string, string> getMissingDetailsFromUser(Dictionary<string, string[]> i_MissingDetails)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string[]> missingDetail in i_MissingDetails)
            {
                string missingDetailToDisplay = TerminalRenderer.parsePropertyToDisplayedProperty(missingDetail.Key);
                string multiChoiceDetailRequest = string.Format(UIMessages.k_VehicleDetailRequestMultiChoice, missingDetailToDisplay);
                string detailRequest = string.Format(UIMessages.k_VehicleDetailRequest, missingDetailToDisplay);

                if (missingDetail.Value != null)
                {
                    TerminalRenderer.renderMultiChoiceRequest(missingDetail.Value, multiChoiceDetailRequest);
                }
                else
                {
                    TerminalRenderer.renderMessage(TerminalRenderer.asActionString(detailRequest));
                }

                string missingDetailValue = readInputLine();

                vehicleDetails.Add(missingDetail.Key, missingDetailValue);
            }

            return vehicleDetails;
        }

        private void showVehicleList()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ShowVehicleListTitle);

            TerminalRenderer.renderFilterByStatusRequest(GarageAgent.GetVehicleStatusTypes());

            int vehicleStatusID = readInputAsInt();

            List<string> filteredList = GarageAgent.GetVehiclesByStatus(vehicleStatusID);

            if (filteredList.Count > 0)
            {
            TerminalRenderer.renderShowVehicleList(filteredList);
            TerminalRenderer.renderSuccsfulActionMessage();
            }
            else
            {
                TerminalRenderer.renderMessageAndRedirect(UIMessages.k_VehicleListEmptyMessage);
            }

        }

        private void modifyVehicleStatus()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ModifyVehicelStatusTitle);

            int vehicleStatusAsNumber;
            string licensePlate = getLicensePlateFromUser();

            string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();

            TerminalRenderer.renderMultiChoiceRequest(vehicleStatusTypes, UIMessages.k_SetVehicleStatusRequest);

            vehicleStatusAsNumber = readInputAsInt();

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

            int userNumChoice = readInputAsInt();
            validateInput(userNumChoice, typeof(eTireInflationOptions));

            eTireInflationOptions chosenInflationOption = (eTireInflationOptions)userNumChoice;
            switch (chosenInflationOption)
            {
                case (eTireInflationOptions.InflateAllToMaxCapacity):
                    GarageAgent.InflateTires(licensePlate, i_InflateToMax: true);
                    break;
                case (eTireInflationOptions.InflateAllToGivenAirPressure):
                    float airPressureToFill = readInputAsFloat(UIMessages.k_SpecifiedAirPressureRequest);
                    GarageAgent.InflateTires(licensePlate, airPressureToFill);
                    break;
            }
            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void fuelVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_FuelVehicleTitle);

            string licensePlate = getLicensePlateFromUser();

            string[] fuelTypes = GarageAgent.GetFuelTypes();

            TerminalRenderer.renderMultiChoiceRequest(fuelTypes, UIMessages.k_FuelVehicleTypeRequest);
            int fuelTypeAsNumber = readInputAsInt();

            float numOfLiters = readInputAsFloat(TerminalRenderer.asActionString(UIMessages.k_NumOfLitersToFuelRequest));

            GarageAgent.ReFuel(licensePlate, fuelTypeAsNumber, numOfLiters);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void chargeBattery()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ChargeBatteryTitle);

            string licensePlate = getLicensePlateFromUser();

            string numOfMinutesToChargeRequest = TerminalRenderer.asActionString(UIMessages.k_NumOfMinutesToChargeRequest);
            float chargingDuration = readInputAsFloat(numOfMinutesToChargeRequest);

            GarageAgent.ReChargeBattery(licensePlate, chargingDuration);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void showVehicleDetails()
        {
            TerminalRenderer.renderTitle(UIMessages.k_VehicleDetailsTitle);
            string licensePlate = getLicensePlateFromUser();
            TerminalRenderer.renderMessage(GarageAgent.GetVehicleProfile(licensePlate));
            TerminalRenderer.renderToContinueMessage();
        }

        private void displayStartUpScreen()
        {
            TerminalRenderer.renderStartUpScreen();
            TerminalRenderer.renderToContinueMessage();

            Console.Clear();
        }

        private static void validateInput(int userNumChoice, Type typeOfEnum)
        {
            if (userNumChoice <= 0 || userNumChoice >= Enum.GetValues(typeOfEnum).Length)
            {
                throw new ArgumentException(UIMessages.k_ArgumentExceptionRange);
            }
        }

        private string readInputLine(string i_MessageDialog = "")
        {
            TerminalRenderer.renderMessage(i_MessageDialog);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput.Equals(k_BackSignalFromUser) == true)
            {
                throw new BackSignalRaiseException();
            }

            return userInput;
        }

        private float readInputAsFloat(string i_MessageDialog = "")
        {
            string inputString = readInputLine(i_MessageDialog);
            bool isParseSuccess = float.TryParse(inputString, out float numToReturn);

            if (!isParseSuccess)
            {
                throw new FormatException(UIMessages.k_FormatExceptionNumParse);
            }

            return numToReturn;
        }

        private int readInputAsInt(string i_MessageDialog = "")
        {
            string inputString = readInputLine(i_MessageDialog);
            bool isParseSuccess = int.TryParse(inputString, out int numToReturn);

            if (!isParseSuccess)
            {
                throw new FormatException(UIMessages.k_FormatExceptionNumParse);
            }

            return numToReturn;
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
