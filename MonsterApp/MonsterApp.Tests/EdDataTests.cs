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

        [Fact]
        public void Test_InsertMonster()
        {
            var data = new EfData();
            var monster = new Monster {
                Name = "Dracula",
                MonsterType = new MonsterType
                {
                    TypeName = "Vampire",
                    Active = true
                },
                Gender = data.GetLatestGender(),
                Title = new Title
                {
                    TitleName = "Count",
                    Active = true
                },
                Active = true
            };
            var expected = 3;

            var actual = data.InsertMonster(monster);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Test_InsertMonster2()
        {
            var data = new EfData();
            var monsterType = data.GetFirstMonsterType();
            var monster = new Monster
            {
                MonsterType = monsterType,
                Name = "Test Mosnter",
                Active = true
            };
            var expected = 1;

            var actual = data.InsertMonster(monster);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Test_GetMonsters()
        {
            var data = new EfData();

            var actual = data.GetMonsters();

            Assert.NotNull(actual);
        }
    }
}
