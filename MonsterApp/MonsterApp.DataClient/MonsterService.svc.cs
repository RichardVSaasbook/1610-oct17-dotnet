using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterApp.DataClient
{
    public class MonsterService : IMonsterService
    {
        public string DoWork()
        {
            return "Hello SOAP!";
        }
    }
}
