using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class EfData
    {
        private MonsterDbEntities db;

        /// <summary>
        /// 
        /// </summary>
        public EfData()
        {
            db = new MonsterDbEntities();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Gender> GetGenders()
        {
            return db.Genders.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Gender GetLatestGender()
        {
            return db.Genders.OrderByDescending(g => g.GenderId).First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public bool InsertGender(Gender gender)
        {
            db.Genders.Add(gender);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ChangeGender(Gender gender, EntityState state)
        {
            var entry = db.Entry<Gender>(gender);
            entry.State = state;
            return db.SaveChanges() > 0;
        }
    }
}
