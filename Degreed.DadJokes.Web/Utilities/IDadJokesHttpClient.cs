using Degreed.DadJokes.Web.Models;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Web.Utilities
{
    public interface IDadJokesHttpClient
    {
        /// <summary>
        /// Checks the Degreed.DadJokes.Api Ping Endpoint is running and connectable
        /// </summary>
        /// <returns></returns>
        Task<bool> Connected();

        /// <summary>
        /// Get a random joke
        /// </summary>
        /// <returns></returns>
        Task<RandomJokeViewModel> GetRandomJoke();

        /// <summary>
        /// Search for jokes containing the given search term
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Task<SearchJokesViewModel> SearchJokes(string searchTerm);
    }
}