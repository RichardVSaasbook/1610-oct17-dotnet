using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess.Models
{
    public class Gender
    {
        public int GenderId { get; set; }

        public string GenderName { get; set; }

        public bool Active { get; set; }
    }
}
