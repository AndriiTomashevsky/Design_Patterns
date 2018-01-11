using System.Collections.Generic;

namespace Step4
{
    // Комбинация должна реализовывать тот же интерфейс, что и листовые элементы
    class Flock : IQuackable
    {
        List<IQuackable> quackers = new List<IQuackable>();

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
                IQuackable quacker = iterator.Current;
                quacker.Quack();
            }
        }
        public override string ToString()
        {
            return "Flock of Quackers";
        }
    }
}
