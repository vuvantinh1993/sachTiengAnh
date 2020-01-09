using Moq;
using CTIN.Domain.Services;
using System;
using Xunit;

namespace CTIN.XUnitTest.Services
{
    public class TempServiceTest
    {
        private readonly Mock<ITempService> sv;

        public TempServiceTest()
        {
            sv = new Mock<ITempService>();
            sv.Setup(x => x.FindOne()).Returns("123");
        }

        [Fact]
        public void FindOneTest()
        {
            var result = sv.Object.FindOne();
            Assert.Equal("123",result);
        }
    }
}
