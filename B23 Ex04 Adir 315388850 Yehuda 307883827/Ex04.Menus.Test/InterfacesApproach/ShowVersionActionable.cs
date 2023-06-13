
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.TestUtils;

namespace Ex04.Menus.Test.InterfacesApproach
{
    internal class ShowVersionActionable : ISelectedObservers
    {
        public void NotifyItemSelected()
        {
            VersionAndCapitalsAgent.ShowVersion();
        }
    }
}
