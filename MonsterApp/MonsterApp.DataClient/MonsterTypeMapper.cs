using MonsterApp.DataAccess.Models;
using MonsterApp.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonsterApp.DataClient
{
    public class MonsterTypeMapper
    {
        public static MonsterTypeDAO MapToMonsterTypeDAO(MonsterType monsterType)
        {
            return new MonsterTypeDAO { Id = monsterType.MonsterTypeId, Name = monsterType.TypeName };
        }
    }
}