using Degreed.DadJokes.Core.ICanHazDadJoke.Models;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Core.ICanHazDadJoke
{
    public interface IICanHazDadJokeHttpClient
    {
        /// <summary>
        /// Calls the ICanHazDadJoke API to return a single joke
        /// </summary>
        Task<ICanHazDadJokeModel> GetRandomJoke();

        /// <summary>
        /// Calls the ICanHazDadJoke API to return up to 30 jokes which contain the search term
        /// </summary>
        /// <param name="searchTerm"></param>
        Task<ICanHazDadJokesModel> GetJokesBySearchTerm(string searchTerm);
    }
}