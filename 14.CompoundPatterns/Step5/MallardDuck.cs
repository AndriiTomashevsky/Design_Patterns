using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3.Интеграция вспомогательного класса Observable с классами IQuackable.

//Задача не такая уж сложная.Все, что нужно, — это позаботиться о том, чтобы классы IQuackable содержали комбинированные объекты 
//Observable и умели делегировать им операции.После этого они готовы к использованию в каче- 
//стве Observable. Ниже приводится реализация MallardDuck; остальные классы выглядят аналогично.

namespace Step5
{
    class MallardDuck : IQuackable
    {
        Observable observable;

        public MallardDuck()
        {
            observable = new Observable(this);
        }

        public void Quack()
        {
            Console.WriteLine("Quack");
            // Наблюдатели оповещаются о вызовах Quack()
            NotifyObservers();
        }

        // Два метода IQuackObservable. Обратите внимание на делегирование операций вспомогательному объекту (Observable)
        public void NotifyObservers()
        {
            observable.NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }
        public override string ToString()
        {
            return "Mallard Duck"; 
        }
    }
}
