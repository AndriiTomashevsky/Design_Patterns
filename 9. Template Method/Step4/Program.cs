using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4
{
    abstract class CaffeineBeverageWithHook
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments()) { AddCondiments(); }
        }
        public abstract void Brew();
        public abstract void AddCondiments();
        public void BoilWater() { Console.WriteLine("Boiling water"); }
        public void PourInCup() { Console.WriteLine("Pouring into cup"); }

        public virtual bool CustomerWantsCondiments() { return true; }
    }
    class CoffeeWithHook : CaffeineBeverageWithHook
    {
        public override void AddCondiments() { Console.WriteLine("Adding Sugar and Milk"); }
        public override void Brew() { Console.WriteLine("Dripping water through filter"); }

        public override bool CustomerWantsCondiments()
        {
            string answer = GetUserInput();

            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string GetUserInput()
        {
            string answer = null;
            Console.Write("Would you like milk and sugar with your coffee (y/n)?");
            try
            {
                answer = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Error trying to read your answer");
            }
            return answer;
        }
    }
    class TeaWithHook : CaffeineBeverageWithHook
    {
        public override void AddCondiments() { Console.WriteLine("Adding Lemon"); }
        public override void Brew() { Console.WriteLine("Steeping the tea"); }
        public override bool CustomerWantsCondiments()
        {
            string answer = GetUserInput();

            if (answer.ToLower().StartsWith("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private string GetUserInput()
        {
            string answer = null;
            Console.Write("Would you like lemon with your tea (y/n)?");
            try
            {
                answer = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Error trying to read your answer");
            }
            return answer;

        }
        class Program
        {
            static void Main(string[] args)
            {
                TeaWithHook teaHook = new TeaWithHook();
                CoffeeWithHook coffeeHook = new CoffeeWithHook();

                Console.WriteLine("\nMaking tea...");
                teaHook.PrepareRecipe();

                Console.WriteLine("\nMaking coffee...");
                coffeeHook.PrepareRecipe();

                Console.ReadKey();
            }
        }
    }
}
