using GarageLogic;
using System;
using System.Linq.Expressions;

namespace ConsoleUI
{
    public class TerminalUserInterface
    {
        private const string k_KillSignal = "Q";

        public static void Main()
        {
            try
            {
                //GarageLogic.Garage garageLogic = new Garage();
                runProgram();
            }
            catch (KillSignalRaisedException)
            {
                TerminalRenderer.renderEndProgramScreen();
            }
        }

        private static void runProgram()
        {
            displayStartUpScreen();
            eInitialAction initialAction = setInitialAction();
            switch (initialAction) {
                case eInitialAction.NewVehicle:
                    AddNewVehicle();
                    break;
                case eInitialAction.ShowVehicleList:
                    ShowVehicleList();
                    break;
                case eInitialAction.SpecifiedVehicleAction:
                    SetSpecifiedVehicleAction();
                    break;
            }
        }

        private static eInitialAction setInitialAction()
        {
            int userNumChoice;
            TerminalRenderer.renderInitialActionScreen();
            int.TryParse(readInputLine(""), out userNumChoice);
            eInitialAction initialAction = (eInitialAction)userNumChoice;
            return initialAction;
        }
        private static void SetSpecifiedVehicleAction()
        {
            int userNumChoice;
            eVehicleType vehicleType; ///GarageLogic.Garage.currentVehicleType
            TerminalRenderer.renderSpecifiedVehicleActionScreen(vehicleType, out userNumChoice);
            eSpecifidVehicleAction specifiedVehicleAction = (eSpecifidVehicleAction)userNumChoice;

        }

        private static void ShowVehicleList()
        {
        }

        private static void AddNewVehicle()
        {

        }

        private static void displayStartUpScreen()
        {
            TerminalRenderer.renderStartUpScreen();
            TerminalRenderer.renderToContinueMessage(UIMessages.k_ToContinueMessage);
            readInputLine("");
            Console.Clear();
        }


        public enum eInitialAction
        {
            Empty = 0,
            NewVehicle = 1,
            ShowVehicleList = 2,
            SpecifiedVehicleAction = 3
        }
        public enum eSpecifidVehicleAction
        {
            Empty = 0,
            ChangeVehicleStatus = 1,
            ReenergizeEnergySource = 2,
            InfalteTires = 3,
            ShowVehicleDetails = 4
        }


        private static string readInputLine(string i_MessageDialog)
        {
            Console.WriteLine();
            TerminalRenderer.renderUserInputRequestMessage(i_MessageDialog);
            string userInput = Console.ReadLine();

            if (userInput.Equals(k_KillSignal) == true)
            {
                throw new KillSignalRaisedException();
            }

            return userInput;
        }
    }
}
