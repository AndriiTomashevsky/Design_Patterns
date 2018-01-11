using System.Collections.Generic;

namespace Step5
{
    // Комбинация должна реализовывать тот же интерфейс, что и листовые элементы
    class Flock : IQuackable
    {
        List<IQuackable> quackers = new List<IQuackable>();
        IQuackable quacker;

        public void Add(IQuackable quacker)
        {
            quackers.Add(quacker);
        }

        public void Quack()
        {
            // Паттерн итератор
            IEnumerator<IQuackable> iterator = quackers.GetEnumerator();
            while (iterator.MoveNext())
            {
                quacker = iterator.Current;
                quacker.Quack();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            // Паттерн итератор
            IEnumerator<IQuackable> iterator = quackers.GetEnumerator();
            while (iterator.MoveNext())
            {
                IQuackable quacker = iterator.Current;
                quacker.RegisterObserver(observer);
            }
        }

        public void NotifyObservers()
        {
           quacker.NotifyObservers();
        }


        public override string ToString()
        {
            return "Flock of Quackers";
        }
    }
}
