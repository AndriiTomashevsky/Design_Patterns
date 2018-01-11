using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Преимущества такой реализации:
// • Локализация поведения каждого состояния в отдельном классе.
// • Исключение многочисленных конструкций if, усложнявших сопровождение кода.
// • Каждое состояние закрыто для изменения, однако сам автомат открыт для расширения посредством добавления новых классов состояний
//   (чем мы вскоре займемся). 
// • Создание кодовой базы и структуры классов, приближенной к диаграмме переходов автомата, а следовательно — более простой для чтения 
//   и понимания.

namespace Step2
{
    // ConcreteStateC
    internal class SoldOutState : IState
    {
        private GumballMachine gumballMachine;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void Refill()
        {
            throw new NotImplementedException();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned, but there are no gumballs");
        }
        public override String ToString()
        {
            return "sold out";
        }

    }
}