using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4
{
    abstract class Beverage
    {
        public string description;
        public static string TALL { get { return "TALL"; } }
        public static string GRANDE { get { return "GRANDE"; } }
        public static string VENTI { get { return "VENTI"; } }

        public virtual string GetDescription() { return description; }
        public abstract double Cost();
        string size;

        public void SetSize(string size) { this.size = size; }
        public string GetSize() { return size; }
    }

    abstract class CondimentDecorator : Beverage
    {
        public override abstract string GetDescription();
    }                                                                                       
    class Milk : CondimentDecorator { Beverage beverage; public Milk(Beverage b) { beverage = b; } public override double Cost() { return beverage.Cost() + 0.10; } public override string GetDescription() { return beverage.GetDescription() + " Milk"; } }
    class Mocha : CondimentDecorator { Beverage beverage; public Mocha(Beverage b) { beverage = b; } public override double Cost() { return beverage.Cost() + 0.20; } public override string GetDescription() { return beverage.GetDescription() + " Mocha"; } }
    class Whip : CondimentDecorator { Beverage beverage; public Whip(Beverage b) { beverage = b; } public override double Cost() { return beverage.Cost() + 0.10; } public override string GetDescription() { return beverage.GetDescription() + " Whip"; } }
    class Soy : CondimentDecorator
    {
        Beverage beverage;
        public Soy(Beverage b) { beverage = b; }
        public override string GetDescription() { return beverage.GetDescription() + " Soy"; }

        public override double Cost()
        {
            double cost = beverage.Cost();
            if (GetSize() == Beverage.TALL) { cost += 0.10; }
            else if (GetSize() == Beverage.GRANDE) { cost += 0.15; }
            else if (GetSize() == Beverage.VENTI) { cost += 0.20; }
            return cost;
        }
    }

    class HouseBlend : Beverage { public HouseBlend() { description = "HouseBlend"; } public override double Cost() { return 0.89; } }
    class DarkRoast : Beverage { public DarkRoast() { description = "DarkRoast"; } public override double Cost() { return 0.99; } }
    class Decaf : Beverage { public Decaf() { description = "Decaf"; } public override double Cost() { return 1.05; } }
    class Espresso : Beverage { public Espresso() { description = "Espresso"; } public override double Cost() { return 1.99; } }

    class Program
    {
        static void Main(string[] args)
        {
            Beverage whip = new Whip(new Mocha(new Mocha(new DarkRoast())));
            Console.WriteLine($"{whip.GetDescription()}, ${whip.Cost()}");

            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);           
            beverage2 = new Mocha(beverage2);           
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"{beverage2.GetDescription()}, ${beverage2.Cost()}");

            //Beverage beverage = new Soy(new Espresso());
            //beverage.SetSize("Small");
            //Console.WriteLine($"{beverage.GetDescription()}, ${beverage.Cost()}");
            Console.WriteLine(new string('-', 30));
            
            Beverage beverage = new Soy(new Decaf());
            beverage.SetSize("VENTI");
            Console.WriteLine(beverage.Cost());

            Console.ReadKey();
        }
    }
}
