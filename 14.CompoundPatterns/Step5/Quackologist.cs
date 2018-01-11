using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Класс наблюдателя прост: единственный метод Update() выводит информацию о реализации IQuackable, от которой поступило оповещение
// Если класс реализует IObserver, это означает, что он наблюдает за IQuackable и будет получать оповещения 
// о вызовах Quack()

namespace Step5
{
    // Наблюдатель должен реализовать интерфейс IObserver, иначе его не удастся зарегистрировать с IQuackObservable
    class Quackologist : IObserver
    {
        public void Update(IQuackObservable duck)
        {
            Console.WriteLine("Quackologist: " + duck + " just quacked.");
        }
    }
}
