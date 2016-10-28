using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterApp.DataAccess;
using Models = MonsterApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterApp.Tests
{
    [TestClass]
    public class AdoDataMSTests
    {
        private AdoData data;
        private Models.Gender gender;
        private Models.Title title;
        private Models.MonsterType monsterType;

        [TestInitialize]
        public void Initialize()
        {
            data = new AdoData();

            gender = new Models.Gender { GenderName = "TestGender" };
            title = new Models.Title { TitleName = "TestTitle" };
            monsterType = new Models.MonsterType { TypeName = "TestType" };
        }

        [TestCleanup]
        public void Cleanup()
        {
            GC.Collect();
        }

        [TestMethod]
        public void Test_InsertGender()
        {
            var actual = data.InsertGender(gender);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test_InsertTitle()
        {
            var actual = data.InsertTitle(title);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Test_InsertMonsterType()
        {
            var actual = data.InsertMonsterType(monsterType);

            Assert.IsTrue(actual);
        }
    }
}
