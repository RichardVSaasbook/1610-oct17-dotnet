using MonsterApp.DataAccess;
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
        [Fact] // Attribute
        public void Test_GetGenders()
        {
            // Arrange
            var data = new AdoData();

            // Act
            var actual = data.GetGenders();

            // Assert
            Assert.NotNull(actual);
        }

        // WRITE TESTS FOR TYPE AND TITLE
        // WRITE NEGATIVE TESTS
    }
}
