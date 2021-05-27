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
    public class SearchControllerUnsuccessfulTests
    {
        private SearchController _controller;

        private string _searchTerm = "hello";

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<SearchController>>();

            var mockService = new Mock<IJokesService>();

            mockService.Setup(m => m.GetJokesBySearchTerm(_searchTerm).Result).Returns(MockJokes.MockRandomJokesUnsuccessful);

            _controller = new SearchController(mockLogger.Object, mockService.Object);
        }

        [Test]
        public void SearchControllerUnsuccessfulTest()
        {
            var result = _controller.Get(_searchTerm).Result as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.IsInstanceOf<Jokes>(result.Value);
            
            var joke = result.Value as Jokes;
            Assert.IsFalse(joke.Success);
            Assert.IsNotEmpty(joke.ErrorMessage);
        }
    }
}
