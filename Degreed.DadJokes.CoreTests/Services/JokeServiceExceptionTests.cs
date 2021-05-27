using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Degreed.DadJokes.CoreTests.Services
{
    public class JokeServiceExceptionTests
    {
        private IJokesService _jokeService;
        private string _exceptionMessage = "invalid request";

        [SetUp]
        public void Setup()
        {
            var mockClient = new Mock<IICanHazDadJokeHttpClient>();
            
            mockClient.Setup(m => m.GetRandomJoke().Result)
                .Throws(new Exception(_exceptionMessage));

            mockClient.Setup(m => m.GetJokesBySearchTerm(It.IsAny<string>()).Result)
                .Throws(new Exception(_exceptionMessage));

            _jokeService = new JokesService(mockClient.Object);
        }

        [Test]
        public async Task JokeServiceRandomJokeExceptionTest()
        {
            var joke = await _jokeService.GetRandomJoke();
            
            Assert.IsFalse(joke.Success);
            Assert.IsNotEmpty(joke.ErrorMessage);
            Assert.AreEqual(_exceptionMessage, joke.ErrorMessage);
        }

        [Test]
        public async Task JokeServiceRandomJokesExceptionTest()
        {
            var searchTerm = "search";
            var jokes = await _jokeService.GetJokesBySearchTerm(searchTerm);

            Assert.IsFalse(jokes.Success);
            Assert.IsNotEmpty(jokes.ErrorMessage);
            Assert.AreEqual(_exceptionMessage, jokes.ErrorMessage);
        }
    }
}
