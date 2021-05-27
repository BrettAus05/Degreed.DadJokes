using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.CoreTests.Mocks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Degreed.DadJokes.CoreTests.ICanHazDadJokes
{
    public class ICanHazDadJokesTests : TestBase
    {
        private ICanHazDadJokeHttpClient _iCanHazDadJokeHttpClient;

        private ICanHazDadJokeSettings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = MockSettings.MockDadJokeSettings;

            var mockHttpClient = InitiateMockHttpClient(_settings, MockHttpContent.MockJokesHttpContent);

            _iCanHazDadJokeHttpClient = new ICanHazDadJokeHttpClient(mockHttpClient, MockSettings.MockDadJokeSettings);
        }

        [Test]
        public async Task ICanHazDadJokesHttpClientSearchTest()
        {
            var searchTerm = "hello";
            var jokes = await _iCanHazDadJokeHttpClient.GetJokesBySearchTerm(searchTerm);

            Assert.IsNotNull(jokes);
            Assert.AreEqual(searchTerm, jokes.SearchTerm);
            Assert.IsTrue(jokes.Status == 200);
            Assert.IsNotNull(jokes.Results);
            Assert.Greater(jokes.Results.Length, 0);
        }
    }
}
