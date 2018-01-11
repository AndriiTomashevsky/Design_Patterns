using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Мы хотели использовать GumballMonitor для работы по сети, но по возможности обойтись без переписывания кода.

namespace Step2.Client
{
    class GumballMonitor
    {
        IGumballMachineRemote machine;

        public GumballMonitor(IGumballMachineRemote machine)
        {
            this.machine = machine;
        }
        public void Report()
        {
            Console.WriteLine("Gumball Machine: " + machine.GetLocation());
            Console.WriteLine("Current inventory: " + machine.GetCount() + " gumballs");
            Console.WriteLine("Current state: " + machine.GetState());
        }
    }
}
