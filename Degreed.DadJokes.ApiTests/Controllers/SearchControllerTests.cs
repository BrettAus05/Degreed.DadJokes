using Degreed.DadJokes.Api.Controllers;
using Degreed.DadJokes.ApiTests.Mocks;
using Degreed.DadJokes.Core.Services;
using Degreed.DadJokes.SharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Degreed.DadJokes.ApiTests.Controllers
{
    public class SearchControllerTests
    {
        private SearchController _controller;

        private string _searchTerm = "hello";

        [SetUp]
        public void Setup()
        {
            var mockLogger = new Mock<ILogger<SearchController>>();

            var mockService = new Mock<IJokesService>();

            mockService.Setup(m => m.GetJokesBySearchTerm(_searchTerm).Result).Returns(MockJokes.MockRandomJokes);

            _controller = new SearchController(mockLogger.Object, mockService.Object);
        }

        [Test]
        public void SearchControllerSuccessfulTest()
        {
            var result = _controller.Get(_searchTerm).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsInstanceOf<Jokes>(result.Value);
            
            var joke = result.Value as Jokes;
            Assert.IsTrue(joke.Success);
            Assert.IsEmpty(joke.ErrorMessage);
            Assert.AreEqual(joke.SearchedTerm, _searchTerm);
            Assert.Greater(joke.MediumJokes.Count(), 0);
        }
    }
}
