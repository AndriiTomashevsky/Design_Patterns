using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    // Service
    class GumballMachine : IGumballMachineRemote
    {
        IState soldOutState;
        IState noQuarterState;
        IState hasQuarterState;
        IState soldState;
        IState winnerState;

        IState state;
        int count = 0;

        string location;

        public GumballMachine()
        {
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);
            winnerState = new WinnerState(this);

            count = 112;
            location = "Seattle";

            state = noQuarterState;
        }

        //public GumballMachine(string location, int numberGumballs)
        //{
        //    soldOutState = new SoldOutState(this);
        //    noQuarterState = new NoQuarterState(this);
        //    hasQuarterState = new HasQuarterState(this);
        //    soldState = new SoldState(this);
        //    winnerState = new WinnerState(this);

        //    count = numberGumballs;
        //    this.location = location;

        //    if (numberGumballs > 0)
        //    {
        //        state = noQuarterState;
        //    }
        //    else
        //    {
        //        state = soldOutState;
        //    }
        //}

        // Implementation IGumballMachineRemote
        #region 
        public int GetCount()
        {
            return count;
        }
        public string GetLocation()
        {
            return location;
        }
        //public IState GetState()
        //{
        //    return state;
        //}

        public string GetState()
        {
            if (state == soldOutState)
            {
               return "sold out";
            }
            else if (state == noQuarterState)
            {
                return "waiting for quarter";
            }
            else if (state == hasQuarterState)
            {
                return "waiting for turn of crank";
            }
            else 
            {
                return"delivering a gumball";
            }
        }
        #endregion

        public void InsertQuarter()
        {
            state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            state.EjectQuarter();
        }

        public void TurnCrank()
        {
            state.TurnCrank();
            state.Dispense();
        }

        public void ReleaseBall()
        {
            Console.WriteLine("A gumball comes rolling out the slot...");
            if (count != 0)
            {
                count = count - 1;
            }
        }

        public void Refill(int count)
        {
            this.count += count;
            Console.WriteLine("The gumball machine was just refilled; it's new count is: " + this.count);
            state.Refill();
        }

        public void SetState(IState state)
        {
            this.state = state;
        }


        public IState GetSoldOutState()
        {
            return soldOutState;
        }

        public IState GetNoQuarterState()
        {
            return noQuarterState;
        }

        public IState GetHasQuarterState()
        {
            return hasQuarterState;
        }

        public IState GetSoldState()
        {
            return soldState;
        }

        public IState GetWinnerState()
        {
            return winnerState;
        }

        public override String ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\nMighty Gumball, Inc.");
            result.Append("\nJava-enabled Standing Gumball Model #2004");
            result.Append("\nInventory: " + count + " gumball");
            if (count != 1)
            {
                result.Append("s");
            }
            result.Append("\n");
            result.Append("Machine is " + state + "\n");
            return result.ToString();
        }

    }
}
