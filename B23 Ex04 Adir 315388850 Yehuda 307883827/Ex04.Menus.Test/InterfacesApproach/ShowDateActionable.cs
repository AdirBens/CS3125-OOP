
using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.TestUtils;

namespace Ex04.Menus.Test.InterfacesApproach
{
    public class ShowDateActionable : ISelectedObservers
    {
        public void NotifyItemSelected()
        {
            DateTimeAgent.ShowDate();
        }
    }
}
