using Degreed.DadJokes.Core.ICanHazDadJoke.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Core.ICanHazDadJoke
{
    public class ICanHazDadJokeHttpClient : IICanHazDadJokeHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICanHazDadJokeSettings _settings;
        
        public ICanHazDadJokeHttpClient(HttpClient httpClient, ICanHazDadJokeSettings settings)
        {
            _settings = settings;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ICanHazDadJokeModel> GetRandomJoke()
        {
            var httpResponse = await _httpClient.GetAsync(_settings.RandomJokeEndpoint);

            httpResponse.EnsureSuccessStatusCode(); // throws execption if not 200 thru to 299

            return await Deserialize<ICanHazDadJokeModel>(httpResponse);
        }

        public async Task<ICanHazDadJokesModel> GetJokesBySearchTerm(string searchTerm)
        {
            var uri = $"{_settings.SearchJokeEndpoint}?limit={_settings.MaxResults}&term={searchTerm}";
            
            var httpResponse = await _httpClient.GetAsync(uri);

            httpResponse.EnsureSuccessStatusCode(); // throws execption if not 200 thru to 299

            return await Deserialize<ICanHazDadJokesModel>(httpResponse);            
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
        {
            var contentStream = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(contentStream);
        }
    }
}
