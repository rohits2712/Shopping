using Shopping.Client.Controllers;
using Xunit;
namespace Shopping.Tests
{
    public class HomeTests
    {
        [Fact]
        public void TestHome() {
            Assert.True(true);
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt() {
            var calc = new calculator();
            var res = calc.Add(1, 2);
            Assert.Equal(3, res);

        }
    }
}
