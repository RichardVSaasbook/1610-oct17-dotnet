using MonsterApp.DataAccess;
using Models = MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MonsterApp.Tests
{
    public partial class AdoDataTests
    {
        private AdoData data;
        private Models.Gender gender;
        private Models.Title title;
        private Models.MonsterType monsterType;

        public AdoDataTests()
        {
            data = new AdoData();

            gender = new Models.Gender { GenderName = "TestGender" };
            title = new Models.Title { TitleName = "TestTitle" };
            monsterType = new Models.MonsterType { TypeName = "TestType" };
        }

        [Fact]
        public void Test_InsertGender()
        {
            var actual = data.InsertGender(gender);

            Assert.True(actual);
        }

        [Fact]
        public void Test_InsertTitle()
        {
            var actual = data.InsertTitle(title);

            Assert.True(actual);
        }

        [Fact]
        public void Test_InsertMonsterType()
        {
            var actual = data.InsertMonsterType(monsterType);

            Assert.True(actual);
        }
    }
}
