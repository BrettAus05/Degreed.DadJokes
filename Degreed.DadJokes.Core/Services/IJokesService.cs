using Degreed.DadJokes.SharedLibrary.Models;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Core.Services
{
    public interface IJokesService
    {
        /// <summary>
        /// Get a random joke
        /// </summary>
        /// <returns>A Joke</returns>
        Task<Joke> GetRandomJoke();
        
        /// <summary>
        /// Search for jokes containing the given search term
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<Jokes> GetJokesBySearchTerm(string searchTerm);
    }
}