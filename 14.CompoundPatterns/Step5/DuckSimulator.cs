using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Observer
namespace Step5
{
    //DuckSimulator(Program) использует фабрику для создания объектов Duck
    class DuckSimulator
    {
        void Simulate(IQuackable duck)
        {
            duck.Quack();
        }

        void Simulate(AbstractDuckFactory duckFactory)
        {
            IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable gooseDuck = new GooseAdapter(new Goose());

            //Создаем объект Flock и заполняем его реализациями IQuackable
            Flock flockOfDucks = new Flock();

            flockOfDucks.Add(redheadDuck);
            flockOfDucks.Add(duckCall);
            flockOfDucks.Add(rubberDuck);
            flockOfDucks.Add(gooseDuck);

            // Затем создаем новый объект Flock, предназначенный только для крякв (MallardDuck)
            Flock flockOfMallards = new Flock();

            IQuackable mallardOne = duckFactory.CreateMallardDuck();
            IQuackable mallardTwo = duckFactory.CreateMallardDuck();
            IQuackable mallardThree = duckFactory.CreateMallardDuck();
            IQuackable mallardFour = duckFactory.CreateMallardDuck();

            flockOfMallards.Add(mallardOne);
            flockOfMallards.Add(mallardTwo);
            flockOfMallards.Add(mallardThree);
            flockOfMallards.Add(mallardFour);

            //А теперь стая крякв добавляется в основную стаю
            flockOfDucks.Add(flockOfMallards);

            Console.WriteLine("Duck Simulator: With Observer");
            Quackologist quackologist = new Quackologist();
            flockOfDucks.RegisterObserver(quackologist);

            Simulate(flockOfDucks);

            Console.WriteLine("\nThe ducks quacked " + QuackCounter.GetQuacks() +  " times");
                          
                         
        }
        // Ничего не изменилось
        static void Main(string[] args)
        {
            DuckSimulator program = new DuckSimulator();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();

            program.Simulate(duckFactory); 

            Console.ReadKey();

        }
    }
}
