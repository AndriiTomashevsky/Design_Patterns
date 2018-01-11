using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step3
{
    // ConcreteStateA
    internal class HasQuarterState : IState
    {
        Random random = new Random();

        GumballMachine gumballMachine;  // Используется для перевода автомата в другое состояние

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.SetState(gumballMachine.GetNoQuarterState());
        }
        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            //Добавляем генератор случайных чисел с 10%-й вероятностью выиграша...
            int randomWinner = random.Next(1, 11);

            // Проверяем повезло ли покупателю
            if ((randomWinner == 1) && (gumballMachine.GetCount() > 1))
            {
                gumballMachine.SetState(gumballMachine.GetWinnerState());
            }
            else
            {
                gumballMachine.SetState(gumballMachine.GetSoldState());
            }
        }
        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void Refill() { }

        public override String ToString()
        {
            return "waiting for turn of crank";
        }

    }
}