using Degreed.DadJokes.Core.ICanHazDadJoke.Models;

namespace Degreed.DadJokes.CoreTests.Mocks
{
    public class MockJokes
    {
        public static ICanHazDadJokeModel MockRandomJoke1 => new ICanHazDadJokeModel
        {
            Id = "1T0gqOZT0g",
            Joke = "If you walk into a forest and cut down a tree, but the tree doesn't understand why you cut it down, do you think it's stumped?",
            Status = 200
        };

        public static ICanHazDadJokeModel MockRandomJoke2 => new ICanHazDadJokeModel
        {
            Id = "ItWLR792Ed",
            Joke = "I'll call you later. Don't call me later, call me Dad.",
            Status = 200
        };

        public static ICanHazDadJokesModel MockRandomJokes => new ICanHazDadJokesModel
        {
            Status = 200,
            Results = new ICanHazDadJokeModel[] { MockRandomJoke1, MockRandomJoke2 },
        };
    }
}
