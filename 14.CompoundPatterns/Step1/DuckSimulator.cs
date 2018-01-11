using System;

//Адаптер
namespace Step1
{
    class DuckSimulator
    {
        // Здесь мы полагаемся на волшебство полиморфизма: какая бы реализация IQuackable ни была передана, Simulate()
        // вызовет ее метод Quack()
        void Simulate(IQuackable duck)
        {
            duck.Quack();
        }
        void Simulate()
        {
            IQuackable mallardDuck = new MallardDuck();
            IQuackable readHeadDuck = new ReadHeadDuck();
            IQuackable duckCall = new DuckCall();
            IQuackable rubberDuck = new RubberDuck();

            //Теперь гуси тоже смогут участвовать в нашей имитации. 
            Goose goose = new Goose();
            // Goose замаскировывается под Duck
            IQuackable gooseDuck = new GooseAdapter(goose); // Goose упаковывается в GooseAdapter

            Console.WriteLine("Duck Simulator : With GooseAdapter");

            Simulate(mallardDuck);
            Simulate(readHeadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);
            Simulate(gooseDuck);      // С адаптироваанным объектом Goose можно работать, как с обычным объектом Duck, реализующем IQuackable
        }
        static void Main(string[] args)
        {
            DuckSimulator program = new DuckSimulator();
            program.Simulate();

            Console.ReadKey();
        }
    }
}
