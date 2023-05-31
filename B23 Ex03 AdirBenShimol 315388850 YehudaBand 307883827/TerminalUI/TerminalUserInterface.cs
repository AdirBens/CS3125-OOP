﻿using System;
using System.Collections.Generic;
using TerminalUI;
using GarageLogic;
using GarageLogic.Exceptions;
using System.Runtime.Remoting.Messaging;

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
                    catch (FormatException fe)
                    {
                        TerminalRenderer.renderExceptionMessage(fe.Message);
                    }
                    catch (ArgumentException fe)
                    {
                        TerminalRenderer.renderExceptionMessage(fe.Message);
                    }
                    ///ASK Adir to change access modifier
                    ///catch (ValueOutOfRangeException) { }
                    catch (BackSignalRaiseException bsre)
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
                    string[] actionChoices = typeof(eUserAction).GetEnumNames();

                    TerminalRenderer.renderTitle(UIMessages.k_MainMenuTitle);
                    TerminalRenderer.renderMultiChoiceRequest(UIMessages.k_ActionListHeaderRequest, actionChoices);

                    int userNumChoice = (int) readInputAsFloat("");
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
            }
        }

        private void registerNewVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_RegisterNewVehicleTitle);
            string licensePlate = getLicensePlateFromUser();

            bool isVehicleInSystem = GarageAgent.LookUpLicensePlate(licensePlate);

            if (!isVehicleInSystem)
            {
                TerminalRenderer.renderMultiChoiceRequest(UIMessages.k_VehicleTypeRequest, GarageAgent.GetSupportedVehicleTypes());
                int vehicleTypeID = (int) readInputAsFloat("");

                Dictionary<string, string[]> missingDetails = GarageAgent.GetRequireadDetails(licensePlate, vehicleTypeID);
                Dictionary<string, string> detailsForAgent;

                detailsForAgent = getMissingDetailsFromUser(missingDetails);
                GarageAgent.SetRequireadDetails(detailsForAgent);

                TerminalRenderer.renderMessageAndRedirect(UIMessages.k_VehicleAddedMessage);
            }
            else
            {
                TerminalRenderer.renderMessage(UIMessages.k_VehicleExistsMessage);
                string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();

                GarageAgent.UpdateVehicleStatus(licensePlate, Array.IndexOf(vehicleStatusTypes, "InRepair")); ////////////////// HANDLE THIS FUCKING SHIIIIT
            }

            TerminalRenderer.renderToContinueMessage();
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
                    TerminalRenderer.renderMultiChoiceRequest(multiChoiceDetailRequest, missingDetail.Value);
                }
                else
                {
                    TerminalRenderer.renderMessage(TerminalRenderer.asActionString(detailRequest));
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

            int vehicleStatusID = (int) readInputAsFloat("");

            List<string> filteredList = null;///DELETE THIS AFTER ADIR CHANGES FROM VOID
            ///List<string> filteredList = GarageAgent.GetVehiclesByStatus(vehicleStatusID);

            TerminalRenderer.renderShowVehicleList(filteredList);
        }

        private void modifyVehicleStatus()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ModifyVehicelStatusTitle);

            int vehicleStatusAsNumber;
            string licensePlate = getLicensePlateFromUser();

            string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();

            TerminalRenderer.renderMultiChoiceRequest(UIMessages.k_SetVehicleStatusRequest, vehicleStatusTypes);

            vehicleStatusAsNumber = (int) readInputAsFloat("");

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

            int userNumChoice = (int)readInputAsFloat("");
            validateInput(userNumChoice, typeof(eTireInflationOptions));

            eTireInflationOptions chosenInflationOption = (eTireInflationOptions)userNumChoice;
            switch (chosenInflationOption)
            {
                case (eTireInflationOptions.InflateAllToMaxCapacity):
                    ///inflate to max implementation  - ADIR
                    GarageAgent.InflateTires(licensePlate, 0);
                    break;
                case (eTireInflationOptions.InflateAllToGivenAirPressure):
                    float PSIToFill;
                    PSIToFill = readInputAsFloat(UIMessages.k_SpecifiedPSIRequest);
                    GarageAgent.InflateTires(licensePlate, PSIToFill);
                    break;
            }
            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void fuelVehicle()
        {
            TerminalRenderer.renderTitle(UIMessages.k_FuelVehicleTitle);

            string licensePlate = getLicensePlateFromUser();

            string[] fuelTypes = GarageAgent.GetFuelTypes();

            TerminalRenderer.renderMultiChoiceRequest(UIMessages.k_FuelVehicleTypeRequest, fuelTypes);
            int fuelTypeAsNumber = (int) readInputAsFloat("");

            float numOfLiters = readInputAsFloat(TerminalRenderer.asActionString(UIMessages.k_NumOfLitersToFuelRequest), true);


            GarageAgent.ReFuel(licensePlate, fuelTypeAsNumber, numOfLiters);

            TerminalRenderer.renderSuccsfulActionMessage();
        }

        private void chargeBattery()
        {
            TerminalRenderer.renderTitle(UIMessages.k_ChargeBatteryTitle);

            string licensePlate = getLicensePlateFromUser();

            string numOfMinutesToChargeRequest = TerminalRenderer.asActionString(UIMessages.k_NumOfMinutesToChargeRequest);
            float chargingDuration = readInputAsFloat(numOfMinutesToChargeRequest, true);

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

        private static void validateInput(int userNumChoice, Type typeOfEnum)
        {
            if (userNumChoice <= 0 || userNumChoice >= Enum.GetValues(typeOfEnum).Length)
            {
                throw new ArgumentException(UIMessages.k_ArgumentExceptionRange);
            }
        }

        private string readInputLine(string i_MessageDialog)
        {
            TerminalRenderer.renderMessage(i_MessageDialog);
            string userInput = Console.ReadLine();

            if (userInput.Equals(k_BackSignalFromUser) == true)
            {
                throw new BackSignalRaiseException();
            }

            return userInput;
        }

        private float readInputAsFloat(string i_MessageDialog, bool executeFloatValidation = false)
        {
            bool isParseSuccess;
            string inputString = readInputLine(i_MessageDialog);
            float numToReturn;

            if (executeFloatValidation)
            {
                isParseSuccess = float.TryParse(inputString, out numToReturn);
            }
            else
            {
                isParseSuccess = int.TryParse(inputString, out int inputNumberInt);
                numToReturn = inputNumberInt;
            }

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
