using Degreed.DadJokes.SharedLibrary.Models;

namespace Degreed.DadJokes.ApiTests.Mocks
{
    public class MockJokes
    {
        public static Joke MockRandomJoke => new Joke("1T0gqOZT0g", "If you walk into a forest and cut down a tree, but the tree doesn't understand why you cut it down, do you think it's stumped?");
        
        public static Joke MockRandomJokeUnsuccessful => new Joke("invalid request");

        public static Jokes MockRandomJokes => new Jokes("hello", new Jokes.Joke[] 
        { 
            new Jokes.Joke("1T0gqOZT0g", "If you walk into a forest and cut down a tree, but the tree doesn't understand why you cut it down, do you think it's stumped?"),
            new Jokes.Joke("ItWLR792Ed", "I'll call you later. Don't call me later, call me Dad."),
        });

        public static Jokes MockRandomJokesUnsuccessful => new Jokes("invalid request");
    }
}
