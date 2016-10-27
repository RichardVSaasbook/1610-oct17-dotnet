using MonsterApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MonsterApp.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class EdDataTests
    {
        [Fact]
        public void Test_GetGenders()
        {
            var data = new EfData();

            var actual = data.GetGenders();

            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_GetLatestGender()
        {
            var data = new EfData();

            var actual = data.GetLatestGender();

            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_InsertGender()
        {
            var data = new EfData();
            var gender = new Gender { GenderName = "Martian", Active = true };

            var actual = data.ChangeGender(gender, System.Data.Entity.EntityState.Added);

            Assert.True(actual);
        }

        [Fact]
        public void Test_UpdateGender()
        {
            var data = new EfData();
            var gender = data.GetGenders()[0];
            gender.GenderName = "Unknown";

            var actual = data.ChangeGender(gender, System.Data.Entity.EntityState.Modified);

            Assert.True(actual);
        }

        [Fact]
        public void Test_DeleteGender()
        {
            var data = new EfData();
            var gender = data.GetGenders()[0];

            var actual = data.ChangeGender(gender, System.Data.Entity.EntityState.Deleted);

            Assert.True(actual);
        }
    }
}
