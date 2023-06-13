
using static Ex04.Menus.Test.InterfacesApproach.InterfacesMainMenu;
using static Ex04.Menus.Test.DelegatesApproach.DelegatesMainMenu;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu interfacesMainMenu = GetInterfacesMainMenu();
            Events.MainMenu delegatesMainMenu = GetDelegatesMainMenu();

            interfacesMainMenu.Show();
            delegatesMainMenu.Show();
        }
    }
}