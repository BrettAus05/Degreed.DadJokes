using Degreed.DadJokes.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace Degreed.DadJokes.ApiTests.Controllers
{
    public class PingControllerTests
    {
        private PingController _controller;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<PingController>>();
            
            _controller = new PingController(mockLogger.Object);
        }

        [Test]
        public void PingControllerSuccessfulTest()
        {
            var result = _controller.Get() as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsInstanceOf<DateTime?>(result.Value);
            Assert.IsTrue(((DateTime?)result.Value).HasValue);
        }
    }
}
