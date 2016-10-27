using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    public partial class AdoData // Partial splits class into two; compiler treats them as the same single class.
    {
        public bool InsertGender(Gender gender)
        {
            return Insert(
                "INSERT INTO Monster.Gender(GenderName, Active) VALUES (@name, 1);",
                new SqlParameter("name", gender.GenderName)) == 1;
        }

        public bool InsertTitle(Title title)
        {
            return Insert(
                "INSERT INTO Monster.Title(TitleName, Active) VALUES (@name, 1);",
                new SqlParameter("name", title.TitleName)) == 1;
        }

        public bool InsertMonsterType(MonsterType monsterType)
        {
            return Insert(
                "INSERT INTO Monster.MonsterType(TypeName, Active) VALUES(@name, 1);",
                new SqlParameter("name", monsterType.TypeName)) == 1;
        }

        private int Insert(string query, params SqlParameter[] parameters)
        {
            int rowsAffected;

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddRange(parameters);

                connection.Open();

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected;
        }
    }
}
