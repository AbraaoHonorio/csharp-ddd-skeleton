using Xunit;

namespace XPTO.Context1.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = new Product("xxxxx");

            Assert.True(x.Validate());
        }
    }
}