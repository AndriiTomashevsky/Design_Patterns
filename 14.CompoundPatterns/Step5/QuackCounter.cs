using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step5
{
    //QuackCounter - декоратор 
    class QuackCounter : IQuackable
    {
        IQuackable duck;                // Переменная для хранения декорируемого объекта
         
        static int numberOfQuacks;

        public QuackCounter(IQuackable duck)
        {
            this.duck = duck;
        }

        public void Quack()
        {
            duck.Quack();         //Вызов Quack() делегируется декорируемой реализации IQuackable...
            numberOfQuacks++;     //...после чего увеличиваем счетчик
        }
        //Статический метод, который возвращает количество кряков во всех реализациях Quackable
        public static int GetQuacks()
        {
            return numberOfQuacks;
        }

        public void RegisterObserver(IObserver observer)
        {
            duck.RegisterObserver(observer);
        }

        public void NotifyObservers()
        {
           duck.NotifyObservers();
        }
    }

}
