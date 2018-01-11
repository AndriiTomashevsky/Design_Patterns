using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    interface IController
    {
        //Методы контроллера, которые могут вызываться представлением.
        void Start();
        void Stop();
        void IncreaseBPM();
        void DecreaseBPM();
        void SetBPM(int beatsPerMinute);
    }
}
