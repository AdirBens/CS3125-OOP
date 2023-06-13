
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.TestUtils;

namespace Ex04.Menus.Test.InterfacesApproach
{
    internal class ShowUpperCountActionable : ISelectedObservers
    {
        public void NotifyItemSelected()
        {
            VersionAndCapitalsAgent.CountCapitals();
        }
    }
}
