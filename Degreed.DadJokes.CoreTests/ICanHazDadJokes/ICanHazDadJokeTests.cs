using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.CoreTests.Mocks;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Degreed.DadJokes.CoreTests.ICanHazDadJokes
{
    public class ICanHazDadJokeTests : TestBase
    {
        private ICanHazDadJokeHttpClient _iCanHazDadJokeHttpClient;

        private ICanHazDadJokeSettings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = MockSettings.MockDadJokeSettings;

            var mockHttpClient = InitiateMockHttpClient(_settings, MockHttpContent.MockJokeHttpContent);

            _iCanHazDadJokeHttpClient = new ICanHazDadJokeHttpClient(mockHttpClient, MockSettings.MockDadJokeSettings);
        }

        [Test]
        public async Task Test1()
        {
            var joke = await _iCanHazDadJokeHttpClient.GetRandomJoke();

            Assert.IsNotNull(joke);
            Assert.IsTrue(joke.Status == 200);
            Assert.IsNotEmpty(joke.Id);
            Assert.IsNotEmpty(joke.Joke);
        }
    }
}
