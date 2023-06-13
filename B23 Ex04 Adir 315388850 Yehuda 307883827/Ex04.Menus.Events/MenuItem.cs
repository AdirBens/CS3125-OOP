
using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        public readonly string Name;
        public event Action ItemSelected;
        private readonly List<MenuItem> r_Childrens = new List<MenuItem>();
        internal int ItemLevel { get; set; }
        internal bool IsTerminal
        {
            get { return r_Childrens.Count == 0; }
        }

        public MenuItem(string i_ItemName)
        {
            Name = i_ItemName;
            ItemLevel = 0;
        }

        public void AddChildren(MenuItem i_ChildrenItem)
        {
            i_ChildrenItem.ItemLevel = ItemLevel + 1;
            r_Childrens.Add(i_ChildrenItem);
        }

        public void RemoveChildren(MenuItem i_ChildrenItem)
        {
            r_Childrens.Remove(i_ChildrenItem);
            i_ChildrenItem.ItemLevel--;
        }

        public MenuItem GetChildItemAt(int i_ChildItemIndex)
        {
            if (i_ChildItemIndex < r_Childrens.Count)
            {
                return r_Childrens[i_ChildItemIndex];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerable<string> GetChildrensIterator()
        {
            foreach (MenuItem childItem in r_Childrens)
            {
                yield return childItem.Name;
            }
        }

        public void OnItemSelected()
        {
            if (!IsTerminal)
            {
                showSubMenu();
            }

            ItemSelected?.Invoke();
        }

        private void showSubMenu()
        {
            ConsoleUtils.RenderMenu(this);
        }
    }
}
