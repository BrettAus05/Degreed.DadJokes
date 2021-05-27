using System.Collections.Generic;

namespace Degreed.DadJokes.Web.Models
{
    public class SearchJokesViewModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int TotalJokes { get; set; }
        public string SearchedTerm { get; set; }
        public List<Joke> SmallJokes { get; set; }
        public List<Joke> MediumJokes { get; set; }
        public List<Joke> LongJokes { get; set; }

        public class Joke
        {
            public string Id { get; set; }

            public string Text { get; set; }
        }
    }
}
