using GarageLogic;
using System;
using System.Collections.Generic;
using TerminalUI;

namespace ConsoleUI
{
    internal class TerminalUserInterface
    {
        GarageAgent m_garageAgent = new GarageAgent();
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

            bool isVehicleInSystem = m_garageAgent.LookUpLicensePlate(licensePlate);

            if (!isVehicleInSystem)
            {
                TerminalRenderer.renderEnterVehicleTypeRequest(m_garageAgent.GetSupportedVehicleTypes());
                vehicleType = readInputLine("");

                Dictionary<string, List<string>> missingDetails = m_garageAgent.GetRequiredDetails(licensePlate, vehicleType);
                Dictionary<string, string> detailsForAgent;

                detailsForAgent = getMissingDetailsFromUser(missingDetails);
                m_garageAgent.SetRequiredDetails(detailsForAgent);

                TerminalRenderer.renderVehicleAddedSuccefullyMessage();
            }
            else
            {
                Console.WriteLine(UIMessages.k_VehicleExistsMessage);
                m_garageAgent.SetVehicleStatusInRepair(licensePlate);
            }

            TerminalRenderer.renderToContinueMessage();
        }

        private Dictionary<string, string> getMissingDetailsFromUser(Dictionary<string, List<string>> i_MissingDetails)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();

            foreach (KeyValuePair<string, List<string>> missingDetail in i_MissingDetails)
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
            TerminalRenderer.renderFilterByStatusRequest(m_garageAgent.GetVehicleStatusTypes());

            string vehicleStatusAsNum = readInputLine("");

            List<string> filteredList = m_garageAgent.GetVehicleList(vehicleStatusAsNum);

            TerminalRenderer.renderShowVehicleList(filteredList);
        }

        private void modifyVehicleStatus()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ModifyVehicelStatusTitle);
            
            string vehicleStatusAsNumber;
            string licensePlate = getLicensePlateFromUser();

            List<string> vehicleStatusTypes = m_garageAgent.GetVehicleStatusTypes();

            TerminalRenderer.renderSetVehicleStatusRequest(vehicleStatusTypes);
            vehicleStatusAsNumber = readInputLine("");

            m_garageAgent.SetVehicleStatus(licensePlate, vehicleStatusAsNumber);

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
                    m_garageAgent.InflateTires(licensePlate, "0");
                    break;
                case (eTireInflationOptions.InflateAllToGivenAirPressure):
                    string PSIToFill;
                    PSIToFill = readInputLine(UIMessages.k_SpecifiedPSIRequest);

                    m_garageAgent.InflateTires(licensePlate, PSIToFill);
                    break;
            }
            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void fuelVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_FuelVehicleTitle);

            string fuelTypeAsNumber;
            string licensePlate = getLicensePlateFromUser();

            List<string> fuelTypes = m_garageAgent.GetFuelTypes();

            TerminalRenderer.renderFuelTypeRequest(fuelTypes);
            fuelTypeAsNumber = readInputLine("");

            string numOfLiters = readInputLine(TerminalRenderer.asActionString(UIMessages.k_NumOfLitersToFuelRequest));

            m_garageAgent.FuelVehicle(licensePlate, fuelTypeAsNumber, numOfLiters);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void chargeBattery()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ChargeBatteryTitle);

            string numOfMinutesToCharge;
            string licensePlate = getLicensePlateFromUser();

            string numOfMinutesToChargeRequest = TerminalRenderer.asActionString(UIMessages.k_NumOfMinutesToChargeRequest);
            numOfMinutesToCharge = readInputLine(numOfMinutesToChargeRequest);

            m_garageAgent.ChargeBattery(licensePlate, numOfMinutesToCharge);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void showVehicleDetails()
        {
            TerminalRenderer.renderTitle(UIMessages.k_VehicleDetailsTitle);

            string licensePlate = getLicensePlateFromUser();

            Dictionary<string, string> vehicleDetails = m_garageAgent.GetVehicleDetails(licensePlate);

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
