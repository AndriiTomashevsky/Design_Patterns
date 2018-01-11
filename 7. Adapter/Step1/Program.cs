using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    interface IDuck
    {
        void Quack();
        void Fly();
    }
    interface ITurkey
    {
        void Gobble();
        void Fly();
    }
    class MallardDuck : IDuck
    {
        public void Quack() { Console.WriteLine("Quack"); }

        public void Fly() { Console.WriteLine("I'm flying"); }
    }
    class WildTurkey : ITurkey
    {
        public void Fly() { Console.WriteLine("I'm flying a short distance"); }

        public void Gobble() { Console.WriteLine("Gobble gobble"); }
    }
    class TurkeyAdapter : IDuck
    {
        ITurkey turkey;

        public TurkeyAdapter(ITurkey turkey) { this.turkey = turkey; }

        public void Fly() { for (int i = 0; i < 5; i++) { turkey.Fly(); } }

        public void Quack() { turkey.Gobble(); }
    }
    class DuckAdapter : ITurkey
    {
        IDuck duck;
        Random random;

        public DuckAdapter(IDuck duck)
        {
            this.duck = duck;
        }

        public void Fly()
        {
            if (random.Next(5) == 0)
            {
                duck.Fly();
            }
        }

        public void Gobble()
        {
            duck.Quack();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MallardDuck duck = new MallardDuck();

            WildTurkey turkey = new WildTurkey();

            IDuck turkeyAdapter = new TurkeyAdapter(turkey);

            Console.WriteLine("The Turkey says...");

            turkey.Gobble();
            turkey.Fly();

            Console.WriteLine("The Duck says...");
            TestDuck(duck);

            Console.WriteLine("TurkeyAdapter says...");
            TestDuck(turkeyAdapter);

            Console.ReadKey();

        }
        static void TestDuck(IDuck duck)
        {
            duck.Quack();
            duck.Fly();
        }
    }
}
