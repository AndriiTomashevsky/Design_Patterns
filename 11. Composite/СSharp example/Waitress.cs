using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СSharp_example
{
    class Waitress
    {
        MenuComponent allMenus;

        public Waitress(MenuComponent allMenus)
        {
            this.allMenus = allMenus;
        }
        public void PrintMenu()
        {
            allMenus.Print();
        }
        /// <summary>
		/// This is a hack! It works but does not offer the encapsulization of a true
		/// composite pattern implementation. Note I have to call the leaf or composite
		/// child menu items explicitly.
		/// I researched how to create an iterator similar to the iterator in the 
		/// java ArrayList and created an internal iterator using IEnumerator and IEnumerable 
		/// interfaces. See the IteratorCSharpFixture object in the Developer Test project.
		/// Needless to say this is where java's ArrayList iterator has one up on .Net's. However,
		/// I am looking forward to C# 2.0 and the use of IEnumerator and IEnumerable with generics.
		/// </summary>
		/// <returns></returns>
        public void PrintVegetarianMenu()
        {
            Console.WriteLine("\nVEGETERIAN MENU\n----");
            GetChildMenuOutPutDown2Levels(allMenus.GetMenu());
        }
        /// <summary>
		/// Get the ArrayList structure down to 2 child node levels. 
		/// Not pretty, but it works
		/// </summary>
		/// <param name="menus"></param>
		/// <returns>Up to 2 child node levels</returns>
        private void GetChildMenuOutPutDown2Levels(ArrayList menus)
        {
            foreach (MenuComponent menuComponent in menus)
            {
                for (int i = 0; i < menuComponent.Count(); i++)
                {
                    if (menuComponent.GetChild(i).IsVegetarian())
                    {
                        menuComponent.GetChild(i).Print();
                    }
                    if (menuComponent.GetChild(i).GetType().Name == "Menu")
                    {
                        for (int j = 0; j < menuComponent.GetChild(i).Count(); j++)
                        {
                            menuComponent.GetChild(i).GetChild(j).Print();
                        }
                    }
                }
            }
        }
        public void PrintBreakfastMenu() { }
        public void PrintLunchMenu() { }
    }
}
