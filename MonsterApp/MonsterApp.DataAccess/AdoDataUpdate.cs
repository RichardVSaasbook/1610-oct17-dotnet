using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    public partial class AdoData
    {
        public bool UpdateGender(Gender gender)
        {
            var query = "UPDATE Monster.Gender SET GenderName = @name, Active = @active WHERE GenderId = @id";
            var name = new SqlParameter("name", gender.GenderName);
            var active = new SqlParameter("active", gender.Active ? 1 : 0);
            var id = new SqlParameter("id", gender.GenderId);

            return ManipulateDataDisconnected(query, name, active, id) > 0;
        }
    }
}
