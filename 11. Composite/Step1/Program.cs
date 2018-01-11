using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Step1
{
    // Component
    public abstract class MenuComponent
    {
        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }
        public virtual MenuComponent GetChild(int i)
        {
            throw new NotImplementedException();
        }
        public virtual String GetName()
        {
            throw new NotImplementedException();
        }
        public virtual String GetDescription()
        {
            throw new NotImplementedException();
        }
        public virtual double GetPrice()
        {
            throw new NotImplementedException();
        }
        public virtual bool IsVegetarian()
        {
            throw new NotImplementedException();
        }
        // Метод Print() реализуется как в Menu, так и в MenuItem
        public virtual void Print()
        {
            throw new NotImplementedException();
        }
    }

    // Leaf
    public class MenuItem : MenuComponent
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
        // Get-методы не отличаются от предыдущей реализации (см.Step5 паттерна Iterator)
        public override string GetName() { return name; }
        public override string GetDescription() { return description; }
        public override double GetPrice() { return price; }
        public override bool IsVegetarian() { return vegetarian; }

        // Добавлен новый метод
        public override void Print()
        {
            Console.Write("  " + GetName());
            if (IsVegetarian())
            {
                Console.Write("(v)");
            }
            Console.WriteLine(", " + GetPrice());
            Console.WriteLine("     -- " + GetDescription());
        }

    }

    // Composite
    public class Menu : MenuComponent
    {
        ArrayList menuComponents = new ArrayList(); // Коллекция для хранения объектов типа MenuComponent 
        string name;
        string description;

        public Menu(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }
        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }
        public override MenuComponent GetChild(int i)
        {
            return (MenuComponent)menuComponents[i];
        }
        public override string GetName()
        {
            return name;
        }
        public override string GetDescription()
        {
            return description;
        }

        public override void Print()
        {
            Console.Write("\n" + GetName());
            Console.WriteLine(", " + GetDescription());
            Console.WriteLine("---------------------");

            IEnumerator iterator = menuComponents.GetEnumerator();
            while (iterator.MoveNext())
            {
                MenuComponent menuComponent = (MenuComponent)iterator.Current;
                menuComponent.Print();
            }
        }
    }

    // Client
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
        public void PrintBreakfastMenu() { }
        public void PrintLunchMenu() { }
        public void PrintVegetarianMenu() { }
        public bool IsVegetarian(string name) { return false; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MenuComponent pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
            MenuComponent dinerMenu = new Menu("DINER MENU", "Lunch");
            MenuComponent cafeMenu = new Menu("CAFE MENU", "Dinner");
            MenuComponent dessertMenu = new Menu("DESSERT MENU", "Dessert of course!");

            MenuComponent allMenus = new Menu("ALL MENUS", "All menus combined");

            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);

            // Добавление элементов в pancakeHouseMenu и dinerMenu
            #region 
            pancakeHouseMenu.Add(new MenuItem(
                "K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                2.99));
            pancakeHouseMenu.Add(new MenuItem(
                "Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                2.99));
            pancakeHouseMenu.Add(new MenuItem(
                "Blueberry Pancakes",
                "Pancakes made with fresh blueberries, and blueberry syrup",
                true,
                3.49));
            pancakeHouseMenu.Add(new MenuItem(
                "Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                3.59));
            dinerMenu.Add(new MenuItem(
                "Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat",
                true,
                2.99));
            dinerMenu.Add(new MenuItem(
                "BLT",
                "Bacon with lettuce & tomato on whole wheat",
                false,
                2.99));
            dinerMenu.Add(new MenuItem(
                "Soup of the day",
                "A bowl of the soup of the day, with a side of potato salad",
                false,
                3.29));
            dinerMenu.Add(new MenuItem(
                "Hotdog",
                "A hot dog, with saurkraut, relish, onions, topped with cheese",
                false,
                3.05));
            dinerMenu.Add(new MenuItem(
                "Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice",
                true,
                3.99));
            dinerMenu.Add(new MenuItem(
                "Pasta",
                "Spaghetti with Marinara Sauce, and a slice of sourdough bread",
                true,
                3.89));
            #endregion

            // В меню также включается другое меню
            dinerMenu.Add(dessertMenu);

            // Добавление элементов в dessertMenu и cafeMenu
            #region 
            dessertMenu.Add(new MenuItem(
                "Apple Pie",
                "Apple pie with a flakey crust, topped with vanilla icecream",
                true,
                1.59));

            dessertMenu.Add(new MenuItem(
                "Cheesecake",
                "Creamy New York cheesecake, with a chocolate graham crust",
                true,
                1.99));
            dessertMenu.Add(new MenuItem(
                "Sorbet",
                "A scoop of raspberry and a scoop of lime",
                true,
                1.89));
            cafeMenu.Add(new MenuItem(
            "Veggie Burger and Air Fries",
            "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
            true,
            3.99));
            cafeMenu.Add(new MenuItem(
                "Soup of the day",
                "A cup of the soup of the day, with a side salad",
                false,
                3.69));
            cafeMenu.Add(new MenuItem(
                "Burrito",
                "A large burrito, with whole pinto beans, salsa, guacamole",
                true,
                4.29));
            #endregion

            Waitress waitress = new Waitress(allMenus);

            waitress.PrintMenu();


            Console.ReadKey();
        }
    }
}
