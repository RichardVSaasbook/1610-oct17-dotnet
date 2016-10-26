using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess.Models
{
    /// <summary>
    /// The type of monsters you can have in movies.
    /// </summary>
    public class MonsterType
    {
        public int MonsterTypeId { get; set; }

        public string TypeName { get; set; }

        public bool Active { get; set; }
    }
}
