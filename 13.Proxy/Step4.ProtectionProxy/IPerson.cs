using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step4.ProtectionProxy
{
    interface IPerson
    {
        string Name { get; set; }
        string Gender { get; set; }
        string Interest { get; set; }
        int HotOrNotRating { get; set; }
    }
}
