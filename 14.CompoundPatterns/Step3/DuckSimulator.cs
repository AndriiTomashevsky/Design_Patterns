using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Abstract Factory
namespace Step3
{
        
    class DuckSimulator
    {
        void Simulate(IQuackable duck)
        {
            duck.Quack();
        }

        //Метод Simulate() получает AbstractDuckFactory и использует фабрику для создания уток(вместо непосредственного создания экземпляров). 
        void Simulate(AbstractDuckFactory duckFactory)
        {
            IQuackable mallardDuck = duckFactory.CreateMallardDuck();
            IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            //IQuackable gooseDuck = new GooseAdapter(new Goose());
            IQuackable gooseDuck = (duckFactory as CountingDuckFactory).CreateGoose();

            Console.WriteLine("Duck Simulator: With Abstract Factory");

            Simulate(mallardDuck);
            Simulate(redheadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);
            Simulate(gooseDuck);

            Console.WriteLine("The ducks quacked " + QuackCounter.GetQuacks() + " times");
        }
        static void Main(string[] args)
        {
            DuckSimulator program = new DuckSimulator();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();

            program.Simulate(duckFactory); // Результат с использованием фабрики тое же, что в Step2 - но на этот раз каждая утка
                                           //заведомо декорируется, потому что мы используем CountingDuckFactory

            Console.ReadKey();
        }
    }
}
