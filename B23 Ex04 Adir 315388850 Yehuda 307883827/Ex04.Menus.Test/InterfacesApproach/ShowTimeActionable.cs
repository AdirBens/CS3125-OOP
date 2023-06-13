
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.TestUtils;

namespace Ex04.Menus.Test.InterfacesApproach
{
    internal class ShowTimeActionable : ISelectedObservers
    {
        public void NotifyItemSelected()
        {
            DateTimeAgent.ShowTime();
        }
    }
}
