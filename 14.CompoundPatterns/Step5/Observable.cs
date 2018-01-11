using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. Теперь нужно позаботиться о том, чтобы все конкретные классы, реализующие IQuackable, могли исполь- 
//зоваться в качестве IQuackObservable.

//Задачу можно решить, реализуя регистрацию и оповещение в каждом классе(как было сделано в главе 2). На этот
//раз мы поступим немного иначе: инкапсулируем код регистрации и оповещения в другом классе — Observable — 
//и объединим его с IQuackObservable.В этом случае реальный код пишется только один раз, а в QuackObservable
//достаточно включить код делегирования вызовов вспомогательному классу Observable.

//Observable реализует всю функциональность, необходимую IQuackable для наблюдения

//Каждая реализация IQuackable содержит экземпляр Observable; с его помощью она отслеживает своих наблюдателей и оповеща- 
//ет их о вызовах Quack().

namespace Step5
{
    class Observable : IQuackObservable
    {
        ArrayList observers = new ArrayList();
        IQuackObservable duck;

        public Observable(IQuackObservable duck)
        {
            this.duck = duck;
        }

        public void NotifyObservers()
        {
            IEnumerator iterator = observers.GetEnumerator();
            while (iterator.MoveNext())
            {
                IObserver observer = (IObserver)iterator.Current;
                observer.Update(duck);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }
    }
}
