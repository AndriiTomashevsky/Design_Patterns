using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step5
{
    abstract class Pizza
    {
        protected string name, dough, sauce;
        protected ArrayList toppings = new ArrayList();

        public void Prepare()
        {
            Console.WriteLine($"Preparing {name}\nTossing dough...\nAdding sauce...\nAdding toppings:");

            for (int i = 0; i < toppings.Count; i++) { Console.WriteLine("    " + toppings[i]); }
        }
        public void Bake() { Console.WriteLine("Bake for 25 minutes at 350"); }
        public virtual void Cut() { Console.WriteLine("Cutting the pizza into diagonal slices"); }
        public void Box() { Console.WriteLine("Place pizza in official PizzaStore box"); }
        public string GetName() { return name; }

    }

    class NYStyleCheesePizza : Pizza { public NYStyleCheesePizza() { name = "NY Style Sauce and Cheese Pizza"; dough = "Thin Crust Dough"; sauce = "Marinara Sauce"; toppings.Add("Grated Regiano cheese"); } }
    class NYStyleGreekPizza : Pizza { }
    class NYStylePepperoniPizza : Pizza { }

    class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza() { name = "Chicago Style Deep Dish Cheese Pizza"; dough = "Extra Thick Crust Dough"; sauce = "Plum Tomato Sauce"; toppings.Add("Shredded Mozzarella cheese"); }
        public override void Cut() { Console.WriteLine("Cutting the pizza into square slices"); }
    }
    class ChicagoStyleGreekPizza : Pizza { }
    class ChicagoStylePepperoniPizza : Pizza { }

    class CaliforniaStyleCheesePizza : Pizza { }
    class CaliforniaStyleGreekPizza : Pizza { }
    class CaliforniaStylePepperoniPizza : Pizza { }

    // Creator
    abstract class PizzaStore
    {
        public Pizza OrderPizza(string kind)
        {
            Pizza pizza;

            pizza = CreatePizza(kind); 

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
        protected abstract Pizza CreatePizza(string kind); 
    }

    // ConcreteCreator
    class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string kind)
        {
            if (kind.ToLower() == "cheese")
                return new NYStyleCheesePizza();  
            else if (kind.ToLower() == "greek")
                return new NYStyleGreekPizza();
            else if (kind.ToLower() == "pepperoni")
                return new NYStylePepperoniPizza();
            else
                return null;
        }
    }
    class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string kind)
        {
            if (kind.ToLower() == "cheese")
                return new ChicagoStyleCheesePizza();  
            else if (kind.ToLower() == "greek")
                return new ChicagoStyleGreekPizza();
            else if (kind.ToLower() == "pepperoni")
                return new ChicagoStylePepperoniPizza();
            else
                return null;
        }
    }
    class CaliforniaPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string kind)
        {
            if (kind.ToLower() == "cheese")
                return new CaliforniaStyleCheesePizza();
            else if (kind.ToLower() == "greek")
                return new CaliforniaStyleGreekPizza();
            else if (kind.ToLower() == "pepperoni")
                return new CaliforniaStylePepperoniPizza();
            else
                return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine($"Ethan ordered a {pizza.GetName()}\n");

            pizza = chicagoStore.OrderPizza("cheese");
            Console.WriteLine($"Joel ordered a {pizza.GetName()}\n");


            Console.ReadKey();
        }
    }
}
