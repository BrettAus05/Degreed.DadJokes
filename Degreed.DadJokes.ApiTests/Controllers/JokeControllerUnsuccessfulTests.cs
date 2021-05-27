using Degreed.DadJokes.Api.Controllers;
using Degreed.DadJokes.ApiTests.Mocks;
using Degreed.DadJokes.Core.Services;
using Degreed.DadJokes.SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Degreed.DadJokes.ApiTests.Controllers
{
    public class JokeControllerUnsuccessfulTests
    {
        private JokeController _controller;

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<JokeController>>();
            
            var mockService = new Mock<IJokesService>();

            mockService.Setup(m => m.GetRandomJoke().Result).Returns(MockJokes.MockRandomJokeUnsuccessful);

            _controller = new JokeController(mockLogger.Object, mockService.Object);
        }

        [Test]
        public void JokeControllerUnsuccessfulTest()
        {
            var result = _controller.Get().Result as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.IsInstanceOf<Joke>(result.Value);
            
            var joke = result.Value as Joke;
            Assert.IsFalse(joke.Success);
            Assert.IsNotEmpty(joke.ErrorMessage);
        }
    }
}
