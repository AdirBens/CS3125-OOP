using System;
using System.Collections.Generic;
using GarageLogic;
using GarageLogic.Exceptions;


namespace ConsoleUI
{
    internal class TerminalUserInterface
    {
        private enum eUserAction
        {
            Empty,
            RegisterNewVehicle,
            ShowVehicleList,
            ChangeVehicleStatus,
            InfalteTires,
            FillFuel,
            ChargeBattery,
            ShowVehicleDetails,
            ExitProgram
        }

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
                                TerminalRenderer.RenderEndProgramScreen();
                                break;
                        }

                        actionFinished = true;
                    }
                    catch (FormatException fe)
                    {
                        TerminalRenderer.RenderExceptionMessage(fe.Message);
                    }
                    catch (ArgumentException ae)
                    {
                        TerminalRenderer.RenderExceptionMessage(string.Format(UIMessages.k_ArgumentExceptionRange, ae.ParamName));
                    }
                    catch (BackSignalRaiseException)
                    {
                        actionFinished = true;
                    }
                    catch (ValueOutOfRangeException voore)
                    {
                        TerminalRenderer.RenderExceptionMessage(voore.Message);
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
                    TerminalRenderer.RenderTitle(UIMessages.k_MainMenuTitle);
                    
                    TerminalRenderer.RenderMultiChoiceRequest(actionChoices, UIMessages.k_ActionListHeaderRequest);
                    int userNumChoice = readInputAsInt();
                    validateInput(userNumChoice, typeof(eUserAction));

                    eUserAction userAction = (eUserAction)userNumChoice;

                    return userAction;
                }
                catch (FormatException ex)
                {
                    TerminalRenderer.RenderExceptionMessage(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    TerminalRenderer.RenderExceptionMessage(ex.Message);
                }
                catch (BackSignalRaiseException)
                {
                    Console.Clear() ;
                }
            }
        }

        private void registerNewVehicle()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_RegisterNewVehicleTitle);
            string licensePlate = getLicensePlateFromUser();
            bool isVehicleInSystem = GarageAgent.LookUpLicensePlate(licensePlate);

            if (!isVehicleInSystem)
            {
                TerminalRenderer.RenderMultiChoiceRequest(GarageAgent.GetSupportedVehicleTypes(), UIMessages.k_VehicleTypeRequest);
                int vehicleTypeID = readInputAsInt();

                Dictionary<string, string[]> missingDetails = GarageAgent.GetRequireadDetails(licensePlate, vehicleTypeID);
                Dictionary<string, string> detailsForAgent;

                detailsForAgent = getMissingDetailsFromUser(missingDetails);
                GarageAgent.SetRequireadDetails(detailsForAgent);

                TerminalRenderer.RenderMessageAndRedirect(UIMessages.k_VehicleAddedMessage);
            }
            else
            {
                TerminalRenderer.RenderMessageAndRedirect(UIMessages.k_VehicleExistsMessage);
            }
        }

        private Dictionary<string, string> getMissingDetailsFromUser(Dictionary<string, string[]> i_MissingDetails)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string[]> missingDetail in i_MissingDetails)
            {
                string missingDetailToDisplay = TerminalRenderer.ParsePropertyToDisplayedProperty(missingDetail.Key);
                string multiChoiceDetailRequest = string.Format(UIMessages.k_VehicleDetailRequestMultiChoice, missingDetailToDisplay);
                string detailRequest = string.Format(UIMessages.k_VehicleDetailRequest, missingDetailToDisplay);

                if (missingDetail.Value != null)
                {
                    TerminalRenderer.RenderMultiChoiceRequest(missingDetail.Value, multiChoiceDetailRequest);
                }
                else
                {
                    TerminalRenderer.RenderMessage(TerminalRenderer.AsActionString(detailRequest));
                }

                string missingDetailValue = readInputLine();

                vehicleDetails.Add(missingDetail.Key, missingDetailValue);
            }

            return vehicleDetails;
        }

        private void showVehicleList()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_ShowVehicleListTitle);
            TerminalRenderer.RenderFilterByStatusRequest(GarageAgent.GetVehicleStatusTypes());

            int vehicleStatusID = readInputAsInt();
            List<string> filteredList = GarageAgent.GetVehiclesByStatus(vehicleStatusID);

            if (filteredList.Count > 0)
            {
                TerminalRenderer.RenderShowVehicleList(filteredList);
                TerminalRenderer.RenderSuccsfulActionMessage();
            }
            else
            {
                TerminalRenderer.RenderMessageAndRedirect(UIMessages.k_VehicleListEmptyMessage);
            }

        }

        private void modifyVehicleStatus()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_ModifyVehicelStatusTitle);
            int vehicleStatusAsNumber;
            string licensePlate = getLicensePlateFromUser();
            string[] vehicleStatusTypes = GarageAgent.GetVehicleStatusTypes();

            TerminalRenderer.RenderMultiChoiceRequest(vehicleStatusTypes, UIMessages.k_SetVehicleStatusRequest);
            vehicleStatusAsNumber = readInputAsInt();
            GarageAgent.UpdateVehicleStatus(licensePlate, vehicleStatusAsNumber);

            TerminalRenderer.RenderSuccsfulActionMessage();
        }

        private string getLicensePlateFromUser()
        {
            string enterLicensePlateMessage = TerminalRenderer.AsActionString(UIMessages.k_LicensePlateRequest);

            return readInputLine(enterLicensePlateMessage);
        }

        private void inflateTires()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_InflateTiresTitle);
            string licensePlate = getLicensePlateFromUser();

            GarageAgent.InflateTiresToMax(licensePlate);
            TerminalRenderer.RenderSuccsfulActionMessage();
        }

        private void fuelVehicle()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_FuelVehicleTitle);
            string licensePlate = getLicensePlateFromUser();

            string[] fuelTypes = GarageAgent.GetFuelTypes();
            TerminalRenderer.RenderMultiChoiceRequest(fuelTypes, UIMessages.k_FuelVehicleTypeRequest);
            int fuelTypeAsNumber = readInputAsInt();

            float numOfLiters = readInputAsFloat(TerminalRenderer.AsActionString(UIMessages.k_NumOfLitersToFuelRequest));
            GarageAgent.ReFuelVehicle(licensePlate, fuelTypeAsNumber, numOfLiters);
            TerminalRenderer.RenderSuccsfulActionMessage();
        }

        private void chargeBattery()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_ChargeBatteryTitle);
            string licensePlate = getLicensePlateFromUser();

            string numOfMinutesToChargeRequest = TerminalRenderer.AsActionString(UIMessages.k_NumOfMinutesToChargeRequest);
            float chargingDuration = readInputAsFloat(numOfMinutesToChargeRequest);
            GarageAgent.ReChargeVehicle(licensePlate, chargingDuration);

            TerminalRenderer.RenderSuccsfulActionMessage();
        }

        private void showVehicleDetails()
        {
            TerminalRenderer.RenderTitle(UIMessages.k_VehicleDetailsTitle);
            string licensePlate = getLicensePlateFromUser();
            
            Console.Clear();
            TerminalRenderer.RenderVehicleDetails(GarageAgent.GetVehicleDetails(licensePlate), licensePlate);
            TerminalRenderer.RenderSuccsfulActionMessage();
        }

        private void displayStartUpScreen()
        {
            TerminalRenderer.RenderStartUpScreen();
            TerminalRenderer.RenderToContinueMessage();

            Console.Clear();
        }

        private static void validateInput(int i_UserNumChoice, Type i_TypeOfEnum)
        {
            int numOfChoices = Enum.GetValues(i_TypeOfEnum).Length;
            
            if (i_UserNumChoice <= 0 || i_UserNumChoice >= numOfChoices)
            {
                throw new ArgumentException(string.Format(UIMessages.k_ValueOutOfRange, 1, numOfChoices));
            }
        }

        private string readInputLine(string i_MessageDialog = "")
        {
            TerminalRenderer.RenderMessage(i_MessageDialog);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput == string.Empty)
            {
                throw new FormatException(UIMessages.k_EmptyInputIsNotAllowed);
            }

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
    }
}
