using Degreed.DadJokes.Core.ICanHazDadJoke;

namespace Degreed.DadJokes.CoreTests.Mocks
{
    public class MockSettings
    {
        public static ICanHazDadJokeSettings MockDadJokeSettings => new ICanHazDadJokeSettings
        {
            MaxResults = 30,
            RandomJokeEndpoint = "api/joke",
            SearchJokeEndpoint = "api/search",
            Uri = "http://www.test.com",
        };
    }
}
