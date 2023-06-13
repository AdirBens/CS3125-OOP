
namespace Ex04.Menus.Test.DelegatesApproach
{
    using Ex04.Menus.Events;
    using Ex04.Menus.Test.TestUtils;

    internal class DelegatesMainMenu
    {
        private static readonly MainMenu sr_MainMenu = new MainMenu("Delegates Main Menu");

        internal static MainMenu GetDelegatesMainMenu()
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

            showDateItem.ItemSelected += DateTimeAgent.ShowDate;
            showTimeItem.ItemSelected += DateTimeAgent.ShowTime;

            sr_MainMenu.AddMenuItem(dateTimeMenu);
            dateTimeMenu.AddChildren(showDateItem);
            dateTimeMenu.AddChildren(showTimeItem);
        }

        private static void setupVersionAndCapitals()
        {
            MenuItem versionAndCapitalsMenu = new MenuItem("Version and Capitals");
            MenuItem showVersionItem = new MenuItem("Show Version");
            MenuItem countCapitalsItem = new MenuItem("Count Capitals");

            showVersionItem.ItemSelected += VersionAndCapitalsAgent.ShowVersion;
            countCapitalsItem.ItemSelected += VersionAndCapitalsAgent.CountCapitals;

            sr_MainMenu.AddMenuItem(versionAndCapitalsMenu);
            versionAndCapitalsMenu.AddChildren(showVersionItem);
            versionAndCapitalsMenu.AddChildren(countCapitalsItem);
        }
    }
}
