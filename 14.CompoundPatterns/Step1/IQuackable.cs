using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    //От реализации этого интерфейса зависит поддержка метода Quack() разными классами.
    interface IQuackable
    {
        void Quack();
    }
}
