
namespace Ex04.Menus.Test.InterfacesApproach
{
    using Ex04.Menus.Interfaces;

    internal class InterfacesMainMenu
    {
        private static readonly MainMenu sr_MainMenu = new MainMenu("Interfaces Main Menu");

        internal static MainMenu GetInterfacesMainMenu()
        {
            setupDateTimeMenu();
            setupVersionAndCapitals();

            return sr_MainMenu;
        }

        private static void setupDateTimeMenu()
        {
            MenuItem dateTimeMenu = new MenuItem("Show Date/Time");
            MenuItem showDateItem = new MenuItem("Show Date");
            MenuItem showTimeItem = new MenuItem("Show Time");

            showDateItem.AttachObserver(new ShowDateActionable());
            showTimeItem.AttachObserver(new ShowTimeActionable());

            sr_MainMenu.AddMenuItem(dateTimeMenu);
            dateTimeMenu.AddChildren(showDateItem);
            dateTimeMenu.AddChildren(showTimeItem);
        }

        private static void setupVersionAndCapitals()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version");
            MenuItem countCapitalsItem = new MenuItem("Count Capitals");

            showVersionItem.AttachObserver(new ShowVersionActionable());
            countCapitalsItem.AttachObserver(new ShowUpperCountActionable());

            sr_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            versionAndCapitalsMenu.AddChildren(showVersionItem);
            versionAndCapitalsMenu.AddChildren(countCapitalsItem);
        }
    }
}
