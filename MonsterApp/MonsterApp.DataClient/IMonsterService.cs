using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterApp.DataClient
{
    [ServiceContract]
    public interface IMonsterService
    {
        [OperationContract]
        string DoWork();

        // void Menu(); // Part of the service contract, but not made available to the outside. (Need OperationContract to do).
    }
}
