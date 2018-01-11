using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    //Как и в паттерне Адаптер, необходимо реализовать целевой интерфейс
    class QuackCounter : IQuackable     //QuackCounter - декоратор 
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
    }

}
