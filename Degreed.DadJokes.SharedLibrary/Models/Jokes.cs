using System.Collections.Generic;
using System.Linq;

namespace Degreed.DadJokes.SharedLibrary.Models
{
    public class Jokes : JokeBase
    {
        private IEnumerable<Joke> _jokeResults = new List<Joke>();

        public Jokes(string errorMessage)
        {
            IsError(errorMessage);
        }   
        
        public Jokes(string searchedTerm, IEnumerable<Joke> jokes)
        {
            SearchedTerm = searchedTerm;
            _jokeResults = jokes;
        }
        
        public string SearchedTerm { get; private set; }
        public IEnumerable<Joke> SmallJokes => _jokeResults.Where(j => j.WordCount < 10);
        public IEnumerable<Joke> MediumJokes => _jokeResults.Where(j => j.WordCount >= 10 && j.WordCount < 20);
        public IEnumerable<Joke> LongJokes => _jokeResults.Where(j => j.WordCount >= 20);
        public int TotalJokes => _jokeResults.Count();

        public class Joke
        {
            public Joke(string id, string text)
            {
                Id = id;
                Text = text;
            }

            public string Id { get; private set; }

            public string Text { get; private set; }

            public int WordCount => string.IsNullOrEmpty(Text) == false ? Text.Split(' ').Length : 0;
        }
    }
}
