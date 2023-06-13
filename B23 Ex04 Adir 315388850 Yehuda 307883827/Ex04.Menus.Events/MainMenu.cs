
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        private readonly Stack<MenuItem> r_ActiveItems;
        private readonly MenuItem r_MainItem;
        private MenuItem m_CurrentActiveItem
        {
            get { return r_ActiveItems.Peek(); }
        }

        public MainMenu(string i_MainTitle)
        {
            r_MainItem = new MenuItem(i_MainTitle);
            r_ActiveItems = new Stack<MenuItem>();

            r_ActiveItems.Push(r_MainItem);
        }

        public void Show()
        {
            while (r_ActiveItems.Count > 0)
            {
                m_CurrentActiveItem.OnItemSelected();
                int selectedItemIndex = ConsoleUtils.GetUserSelection(m_CurrentActiveItem);

                if (selectedItemIndex == 0)
                {
                    r_ActiveItems.Pop();
                }
                else
                {
                    r_ActiveItems.Push(m_CurrentActiveItem.GetChildItemAt(selectedItemIndex - 1));
                }
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MainItem.AddChildren(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_MainItem.RemoveChildren(i_MenuItem);
        }
    }
}
