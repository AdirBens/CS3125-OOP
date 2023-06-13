
using static Ex04.Menus.Test.InterfacesApproach.InterfacesMainMenu;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMainMenu = GetInterfacesMainMenu();

            interfacesMainMenu.Show();
        }
    }
}