using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Декоратор
namespace Step2
{
    class DuckSimulator
    {
        void Simulate(IQuackable duck)
        {
            duck.Quack();
        }
        void Simulate()
        {
            //Обновляем программу, чтобы в ней создавались декорированные реализации IQuackable. 
            //Каждая вновь создаваемая реализация IQuackable упаковывается в декоратор
            IQuackable mallardDuck = new QuackCounter(new MallardDuck());
            IQuackable readHeadDuck = new QuackCounter(new ReadHeadDuck());
            IQuackable duckCall = new QuackCounter(new DuckCall());
            IQuackable rubberDuck = new QuackCounter(new RubberDuck());

            //Гусиные крики ученых не интересуют, поэтому объекты Goose не декорируются
            IQuackable gooseDuck = new GooseAdapter(new Goose());   // Goose упаковывается в GooseAdapter

            Console.WriteLine("Duck Simulator : With Decorator");

            Simulate(mallardDuck);
            Simulate(readHeadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);
            Simulate(gooseDuck);      // С адаптироваанным объектом Goose можно работать, как с обычным объектом Duck, реализующем IQuackable

            Console.WriteLine("The ducks quacked " + QuackCounter.GetQuacks() + " times");
        }
        static void Main(string[] args)
        {
            DuckSimulator program = new DuckSimulator();
            program.Simulate();

            Console.ReadKey();
        }
    }
}
