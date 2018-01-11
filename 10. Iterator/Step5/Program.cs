using System;
using System.Collections;

namespace Step5
{
    // Aggregate
    public interface IMenu
    {
        IEnumerator CreateIterator();
    }
    public class MenuItem
    {
        string name;
        string description;
        bool vegetarian;
        double price;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }
        public string GetName() { return name; }
        public string GetDescription() { return description; }
        public double GetPrice() { return price; }
        public bool IsVegetarian() { return vegetarian; }
    }

    // ConcreteAggregate
    public class PancakeHouseMenu : IMenu
    {
        ArrayList menuItems;

        public PancakeHouseMenu()
        {
            menuItems = new ArrayList();

            AddItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                2.99);

            AddItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99);

            AddItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries, and blueberry syrup",
                true,
                3.49);

            AddItem("Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                3.59);
        }

        public void AddItem(String name, String description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(menuItem);
        }
        // Вместо создания собственного итератора мы просто вызываем метод GetEnumerator для объекта menuItems
        public IEnumerator CreateIterator()
        {
            // ConcreteIterator
            return menuItems.GetEnumerator();
        }
        // other menu methods here
    }

    public class DinerMenu : IMenu
    {
        MenuItem[] menuItems;
        const int MAX_ITEMS = 6;
        int numberOfItems = 0;
        public DinerMenu()
        {
            menuItems = new MenuItem[MAX_ITEMS];

            AddItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT",
                "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            AddItem("Soup of the day",
                "Soup of the day, with a side of potato salad", false, 3.29);
            AddItem("Hotdog",
                "A hot dog, with saurkraut, relish, onions, topped with cheese",
                false, 3.05);
            AddItem("Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice", true, 3.99);
            AddItem("Pasta",
                "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                true, 3.89);
        }

        public void AddItem(String name, String description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);

            if (numberOfItems >= MAX_ITEMS)
            {
                Console.WriteLine("Sorry, menu is full!  Can't add item to menu");
            }
            else
            {
                menuItems[numberOfItems] = menuItem;
                numberOfItems = numberOfItems + 1;
            }
        }

        public IEnumerator CreateIterator()
        {
            return new DinerMenuIterator(menuItems);
            // Второй способ
            // return menuItems.GetEnumerator();
        }

        // other menu methods here
    }

    public class CafeMenu : IMenu
    {
        // Класс Hashtable часто используется для хранения данных.
        Hashtable menuItems = new Hashtable();

        public CafeMenu()
        {
            AddItem("Veggie Burger and Air Fries",
                "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
                true, 3.99);
            AddItem("Soup of the day",
                "A cup of the soup of the day, with a side salad",
                false, 3.69);
            AddItem("Burrito",
                "A large burrito, with whole pinto beans, salsa, guacamole",
                true, 4.29);
        }

        public void AddItem(String name, String description, bool vegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, vegetarian, price);
            menuItems.Add(menuItem.GetName(), menuItem);
        }


        public IEnumerator CreateIterator()
        {
            return menuItems.Values.GetEnumerator();
        }
    }

    // ConcreteIterator
    public class DinerMenuIterator : IEnumerator // IEnumerator = <<interface>> Iterator на диаграме UML 
    {
        MenuItem[] items;
        int position = 0;         // текущая позиция перебора в массиве

        public DinerMenuIterator(MenuItem[] items)
        {
            this.items = items;
        }

        // Реализация Inumerator
        #region 
        public object Current
        {
            get
            {
                MenuItem menuItem = items[position];
                position = position + 1;
                return menuItem;
            }
        }
        public bool MoveNext()
        {
            // Так как DinerMenu использует массив фиксированного размера, нужно проверить не только достижение
            // границы массива, но и равенство следующего элемента null(признак последнего элемента).
            if (position >= items.Length || items[position] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            position = 0;
        }
        #endregion

        public void Remove()
        {
            if (position <= 0)
            {
                throw new InvalidOperationException("You can't remove an item until you've done at least one Current()");
            }
            if (items[position - 1] != null)
            {
                for (int i = position - 1; i < (items.Length - 1); i++)
                {
                    items[i] = items[i + 1];
                }
                items[items.Length - 1] = null;
            }
        }

        // other menu methods here
    }

    // Client
    class Waitress
    {
        ArrayList menus;

        public Waitress(ArrayList menus)
        {
            this.menus = menus;
        }

        public void PrintMenu()
        {
            IEnumerator menuIterator = menus.GetEnumerator();
            while (menuIterator.MoveNext())
            {
                IMenu menu = (IMenu)menuIterator.Current;
                PrintMenu(menu.CreateIterator());
            }
        }
        private void PrintMenu(IEnumerator iterator)
        {
            while (iterator.MoveNext())
            {
                MenuItem menuItem = (MenuItem)iterator.Current;
                Console.Write(menuItem.GetName() + ", ");
                Console.Write(menuItem.GetPrice() + " -- ");
                Console.WriteLine(menuItem.GetDescription());
            }
        }
        public void PrintBreakfastMenu() { }
        public void PrintLunchMenu() { }
        public void PrintVegetarianMenu() { }
        public bool IsVegetarian(string name) { return false; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new PancakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();
            CafeMenu cafeMenu = new CafeMenu();
            ArrayList menus = new ArrayList() { pancakeHouseMenu, dinerMenu, cafeMenu };

            Waitress waitress = new Waitress(menus);

            waitress.PrintMenu();

            Console.ReadKey();
        }
    }
}
