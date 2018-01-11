using System;

namespace Step2
{
    internal class WinnerState : IState
    {
        // Как в SoldState
        #region 
        private GumballMachine gumballMachine;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a Gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning again doesn't get you another gumball!");
        }
        #endregion 

        // Выдаем два шарика
        public void Dispense()
        {
            gumballMachine.ReleaseBall();

            if (gumballMachine.GetCount() == 0)
            {
                gumballMachine.SetState(gumballMachine.GetSoldOutState());
            }
            // Если в автомате есть второй шарик, освобождаем его
            else
            {
                Console.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter");
                gumballMachine.ReleaseBall();
                
                if (gumballMachine.GetCount() > 0)
                {
                    gumballMachine.SetState(gumballMachine.GetNoQuarterState());
                }
                else
                {
                    Console.WriteLine("Oops, out of gumballs!");
                    gumballMachine.SetState(gumballMachine.GetSoldOutState());
                }
            }

        }

        public void Refill() { }

        public override String ToString()
        {
            return "dispensing a gumball";
        }
    }
}