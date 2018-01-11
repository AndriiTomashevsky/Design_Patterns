using System;


//Composite
namespace Step4
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
            IQuackable mallardDuck = duckFactory.CreateMallardDuck();
            IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable gooseDuck = new GooseAdapter(new Goose());

            Console.WriteLine("Duck Simulator: With Composite - Flocks");

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

            Console.WriteLine("\nDuck Simulator: Whole Flock Simulation");
            Simulate(flockOfDucks);

            Console.WriteLine("\nDuck Simulator: Mallard Flock Simulation");
            Simulate(flockOfMallards);

            Console.WriteLine("\nThe ducks quacked " + QuackCounter.GetQuacks() + " times");
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
