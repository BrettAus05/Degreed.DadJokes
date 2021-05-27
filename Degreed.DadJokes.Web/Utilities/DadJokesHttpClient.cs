using Degreed.DadJokes.Web.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Web.Utilities
{
    public class DadJokesHttpClient : IDadJokesHttpClient
    {
        private readonly HttpClient _httpClient;

        public DadJokesHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> Connected()
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync("api/ping");

                var ping = await Deserialize<DateTime?>(httpResponse);

                if (ping.HasValue)
                {
                    return true;
                }

            }
            catch (Exception)
            {
                // nothing to do, UI will display relevant message
            }
            
            return false;
        }

        public async Task<RandomJokeViewModel> GetRandomJoke()
        {
            var httpResponse = await _httpClient.GetAsync("api/joke");

            var randomJoke = await Deserialize<RandomJokeViewModel>(httpResponse);
            
            return randomJoke;
        }

        public async Task<SearchJokesViewModel> SearchJokes(string searchTerm)
        {
            var httpResponse = await _httpClient.GetAsync($"api/search?searchTerm={searchTerm}");

            var searchedJokes = await Deserialize<SearchJokesViewModel>(httpResponse);

            return searchedJokes;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
        {
            var contentStream = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(contentStream);
        }
    }
}
