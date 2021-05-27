using Degreed.DadJokes.SharedLibrary.Models;
using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.Core.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Core.Services
{
    public class JokesService : IJokesService
    {
        private readonly IICanHazDadJokeHttpClient _iCanHazDadJokeHttpClient;

        public JokesService(IICanHazDadJokeHttpClient iCanHazDadJokeHttpClient)
        {
            _iCanHazDadJokeHttpClient = iCanHazDadJokeHttpClient;
        }

        public async Task<Joke> GetRandomJoke()
        {
            try
            {
                var joke = await _iCanHazDadJokeHttpClient.GetRandomJoke();

                return new Joke(joke.Id, joke.Joke);
            }
            catch (Exception e)
            {
                return new Joke(e.Message);
            }
        }

        public async Task<Jokes> GetJokesBySearchTerm(string searchTerm)
        {
            try
            {
                // Note: 
                // The search term is passed to the external API 'as is'
                // No validation done as the API is quite flexible (as in allows any text...)
                
                var jokes = await _iCanHazDadJokeHttpClient.GetJokesBySearchTerm(searchTerm);

                // This logic to me feels like UI / display logic
                // However added it in here to ensure UI is simple as possible
                var jokeResults = jokes.Results.Select(j => new Jokes.Joke(j.Id, j.Joke.Emphasize(searchTerm)));

                return new Jokes(searchTerm, jokeResults);
            }
            catch (Exception e)
            {
                return new Jokes(e.Message);
            }
        }
    }
}
