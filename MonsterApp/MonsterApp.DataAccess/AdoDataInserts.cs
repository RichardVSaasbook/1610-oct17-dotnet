using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AdoData // Partial splits class into two; compiler treats them as the same single class.
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public bool InsertGender(Models.Gender gender)
        {
            return ManipulateDataDisconnected(
                "INSERT INTO Monster.Gender(GenderName, Active) VALUES (@name, 1);",
                new SqlParameter("name", gender.GenderName)) == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool InsertTitle(Models.Title title)
        {
            return ManipulateDataDisconnected(
                "INSERT INTO Monster.Title(TitleName, Active) VALUES (@name, 1);",
                new SqlParameter("name", title.TitleName)) == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monsterType"></param>
        /// <returns></returns>
        public bool InsertMonsterType(Models.MonsterType monsterType)
        {
            return ManipulateDataDisconnected(
                "INSERT INTO Monster.MonsterType(TypeName, Active) VALUES(@name, 1);",
                new SqlParameter("name", monsterType.TypeName)) == 1;
        }
    }
}
