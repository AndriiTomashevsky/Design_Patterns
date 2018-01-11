using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Step2
{
    // IConatract
    [ServiceContract]
    interface IGumballMachineRemote
    {
        [OperationContract]
        int GetCount();

        [OperationContract]
        string GetLocation();

        [OperationContract]
        string GetState();
    }
}
