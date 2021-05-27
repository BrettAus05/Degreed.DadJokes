using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.Core.Services;
using Degreed.DadJokes.CoreTests.Mocks;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Degreed.DadJokes.CoreTests.Services
{
    public class JokeServiceTests
    {
        private IJokesService _jokeService;

        [SetUp]
        public void Setup()
        {
            var mockClient = new Mock<IICanHazDadJokeHttpClient>();
            
            mockClient.Setup(m => m.GetRandomJoke().Result)
                .Returns(MockJokes.MockRandomJoke1);

            mockClient.Setup(m => m.GetJokesBySearchTerm(It.IsAny<string>()).Result)
                .Returns(MockJokes.MockRandomJokes);

            _jokeService = new JokesService(mockClient.Object);
        }

        [Test]
        public async Task JokeServiceRandomJokeValidTest()
        {
            var joke = await _jokeService.GetRandomJoke();
            
            Assert.IsTrue(joke.Success);
            Assert.IsTrue(string.IsNullOrEmpty(joke.ErrorMessage));
            Assert.IsNotEmpty(joke.Id);
            Assert.IsNotEmpty(joke.Text);
        }

        [Test]
        public async Task JokeServiceRandomJokesValidTest()
        {
            var searchTerm = "search";
            var jokes = await _jokeService.GetJokesBySearchTerm(searchTerm);

            Assert.IsTrue(jokes.Success);
            Assert.IsTrue(string.IsNullOrEmpty(jokes.ErrorMessage));
            Assert.AreEqual(jokes.TotalJokes, 2);
            Assert.IsNotEmpty(jokes.SearchedTerm);
            Assert.AreEqual(searchTerm, jokes.SearchedTerm);
        }
    }
}
