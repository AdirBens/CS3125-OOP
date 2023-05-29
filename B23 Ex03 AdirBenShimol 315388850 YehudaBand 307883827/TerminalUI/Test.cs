using ConsoleUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerminalUI
{
    internal class Test
    {
        public static void Main()
        {
            Console.WriteLine(TerminalRenderer.asMarkedString(UIMessages.k_ProgramTitle));
            Console.WriteLine(TerminalRenderer.asWarningString(UIMessages.k_ProgramTitle));
            Console.WriteLine(UIMessages.k_InitialActionList);
            Console.WriteLine(UIMessages.k_ActionListHeader);
            Console.WriteLine(UIMessages.k_SpecifiedVehicleActionList);
            Console.WriteLine(UIMessages.k_RefuelVehicleFuelTankAction);
            Console.WriteLine(UIMessages.k_ChargeVehicleBatteryAction);
            Thread.Sleep(5000);
            Console.Clear();
            Thread.Sleep(2000);

        }
    }
}
