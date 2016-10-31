using MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    /* 
     * 2 types of modifiers:
     *  - access modifiers
     *    - private      |   Most restrictive
     *    - protected    |
     *    - internal    \ /                         // Works within the assembly; this is the default modifier.
     *    - public       `   Least restrictive
     *  - extended modifiers                        // Additional modifiers on top
     *    - static      (class)
     *    - sealed      (only class)
     *    - virtual
     *    - abstract    (class)
     *    - new
     *    - partial     (class)
     *    - override
     *    - readonly
     *    - const
     * 
     * - Fields                                     // Variables
     * - Constructors
     * - Properties                                 // Variables with getter/setter methods
     * - Methods
     * - Functions                                  // Function can be passed to parameters of methods
     * - Destructors
     */

    /// <summary>
    /// 
    /// </summary>
    public partial class AdoData
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MonsterDB"].ConnectionString;

        #region Methods
        
        /// <returns>A List of all Genders.</returns>
        public List<Models.Gender> GetGenders()
        {
            try
            {
                List<Models.Gender> genders = new List<Models.Gender>();
                var ds = GetDataDisconnected("SELECT * FROM Monster.Gender;");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    genders.Add(new Models.Gender
                    {
                        GenderId = int.Parse(row[0].ToString()),
                        GenderName = row[1].ToString(),
                        Active = bool.Parse(row[2].ToString())
                    });
                }

                return genders;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public Models.Gender GetLastestGender()
        {
            try
            {
                List<Models.Gender> genders = new List<Models.Gender>();
                var ds = GetDataDisconnected("SELECT TOP 1 * FROM Monster.Gender ORDER BY GenderId DESC");

                DataRow row = ds.Tables[0].Rows[0];

                return new Models.Gender
                {
                    GenderId = int.Parse(row[0].ToString()),
                    GenderName = row[1].ToString(),
                    Active = bool.Parse(row[2].ToString())
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        /// <returns>A List of all MonsterTypes.</returns>
        public List<Models.MonsterType> GetMonsterTypes()
        {
            try
            {
                List<Models.MonsterType> monsterTypes = new List<Models.MonsterType>();
                var ds = GetDataDisconnected("SELECT * FROM Monster.MonsterType;");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    monsterTypes.Add(new Models.MonsterType
                    {
                        MonsterTypeId = int.Parse(row[0].ToString()),
                        TypeName = row[1].ToString(),
                        Active = bool.Parse(row[2].ToString())
                    });
                }

                return monsterTypes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }
        
        /// <returns>A List of all Titles.</returns>
        public List<Models.Title> GetTitles()
        {
            try
            {
                List<Models.Title> titles = new List<Models.Title>();
                var ds = GetDataDisconnected("SELECT * FROM Monster.Title;");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    titles.Add(new Models.Title
                    {
                        TitleId = int.Parse(row[0].ToString()),
                        TitleName = row[1].ToString(),
                        Active = bool.Parse(row[2].ToString())
                    });
                }

                return titles;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataSet GetDataDisconnected(string query)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd;

            using (var connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(query, connection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private int ManipulateDataDisconnected(string query, params SqlParameter[] parameters)
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
