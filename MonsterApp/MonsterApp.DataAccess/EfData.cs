using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.DataAccess
{
    /// <summary>
    /// Data access for MonsterDB using Entity Framework.
    /// </summary>
    public class EfData
    {
        private MonsterDbEntities db;

        /// <summary>
        /// Create a new instance to start grabbing data.
        /// </summary>
        public EfData()
        {
            db = new MonsterDbEntities();
        }
        
        /// <returns>A list of all Monsters.</returns>
        public List<Monster> GetMonsters()
        {
            return db.Monsters.ToList();
        }
        
        /// <returns>A list of all Genders.</returns>
        public List<Gender> GetGenders()
        {
            return db.Genders.ToList();
        }
        
        /// <returns>A list of all MonsterTypes.</returns>
        public List<MonsterType> GetMonsterTypes()
        {
            return db.MonsterTypes.ToList();
        }
        
        /// <returns>A list of all Titles.</returns>
        public List<Title> GetTitles()
        {
            return db.Titles.ToList();
        }
        
        /// <returns>The Gender with the highest ID.</returns>
        public Gender GetLatestGender()
        {
            return db.Genders.OrderByDescending(g => g.GenderId).First();
        }
        
        /// <summary>
        /// Searches the Gender table for all Genders with a GenderName which includes "ma".
        /// </summary>
        /// <returns>The list of Genders.</returns>
        public List<Gender> SearchGender()
        {
            // !!! lambda is to collection as method is to object
            //     No real reason to use lambda on single object.
            //     In mathematics lambda means small change of operation.

            // A predicate is data for lambdas.
            //     |
            //     `--> Conditional data to a lambda. (Narrows down the set of data)

            // Where filters out data. (Remove that don't match)
            // Select grabs the data.  (Add that do match)

            //                        Lambda expression
            //                       .------------------.
            //                       |      Conditional |
            //                       |     .-----------.|
            var actives = db.Genders.Where(a => a.Active);
            var inactives = db.Genders.Where(a => !a.Active);
            var ma = db.Genders.Where(m => m.GenderName.ToLower().Contains("ma"));

            return ma.ToList();
        }

        /// <summary>
        /// Insert a Gender into the database.
        /// </summary>
        /// <param name="gender">The Gender to insert.</param>
        /// <returns>True if the insert was successful.</returns>
        public bool InsertGender(Gender gender)
        {
            db.Genders.Add(gender);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Insert, Update, or Delete a Gender into the database.
        /// </summary>
        /// <param name="gender">The Gender to modify.</param>
        /// <param name="state">The database operation to perform.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool ChangeGender(Gender gender, EntityState state)
        {
            var entry = db.Entry<Gender>(gender);
            entry.State = state;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Insert, Update, or Delete a MonsterType into the database.
        /// </summary>
        /// <param name="monsterType">The MonsterType to modify.</param>
        /// <param name="state">The database operation to perform.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool ChangeMonsterType(MonsterType monsterType, EntityState state)
        {
            var entry = db.Entry(monsterType);
            entry.State = state;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Insert, Update, or Delete a Title into the database.
        /// </summary>
        /// <param name="title">The Title to modify.</param>
        /// <param name="state">The database operation to perform.</param>
        /// <returns>True if the modification was successful.</returns>
        public bool ChangeTitle(Title title, EntityState state)
        {
            var entry = db.Entry(title);
            entry.State = state;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Inserts a Monster (and any associated MonsterTypes, Genders, or Titles if necessary) into the table.
        /// </summary>
        /// <param name="monster">The Monster to insert.</param>
        /// <returns>True if the insert was successful.</returns>
        public int InsertMonster(Monster monster)
        {
            db.Monsters.Add(monster);
            return db.SaveChanges();
        }
        
        /// <returns>The first MonsterType in the database.</returns>
        public MonsterType GetFirstMonsterType()
        {
            return db.MonsterTypes.First();
        }
    }
}
