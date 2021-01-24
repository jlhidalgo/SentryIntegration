using SentryIntegration.Controllers;
using Xunit;

namespace SentryIntegrationTests.Controllers 
{
    public class StatusControllerTests
    {
        [Fact]
        public void ShouldReturnStatusOk()
        {
            var sut = new StatusController();
            var response = sut.Get();

            Assert.Equal("OK", response.Status);
            Assert.False(string.IsNullOrEmpty(response.Version));
        }
    }
}