using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1.Сначала определяем интерфейс наблюдаемого объекта.

//Напомним, что интерфейс наблюдаемого объекта содержит методы регистрации и оповещения наблюдателей.Также можно включить в него метод
//удаления наблюдателей, но мы опустим его, чтобы по возможности упростить реализацию. 

namespace Step5
{
    // Чтобы за IQuackable можно было наблюдать, они должны реализовывать интерфейс IQuackObservable
    interface IQuackObservable
    {
        // Метод регистрации наблюдателей. Любой объект, реализующий интерфнйс IObserver, сможет получать оповещения.
        void RegisterObserver(IObserver observer);

        // Метод оповещения наблюдателей
        void NotifyObservers();
    }
}
