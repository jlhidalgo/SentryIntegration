using System;
using Moq;
using SentryIntegration.Controllers;
using SentryIntegration.Interfaces;
using Xunit;

namespace SentryIntegrationTests.Controllers 
{
    public class StatusControllerTests
    {


        [Fact]
        public void ShouldReturnStatusOk()
        {
            var loggerMock = new Mock<ILoggerManager>();
            var sut = new StatusController(loggerMock.Object);
            var response = sut.Get();

            Assert.Equal("OK", response.Status);
            Assert.False(string.IsNullOrEmpty(response.Version));
        }

        [Fact]
        public void ShouldThrowExceptionInPostMethod()
        {
            var loggerMock = new Mock<ILoggerManager>();
            var sut = new StatusController(loggerMock.Object);

            Exception ex = Assert.Throws<NotImplementedException>(() => sut.NotImplemented());
            Assert.Equal("This method has not been implemented yet", ex.Message);
        
        }
    }
}