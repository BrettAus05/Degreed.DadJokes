using Newtonsoft.Json;

namespace Degreed.DadJokes.Core.ICanHazDadJoke.Models
{
    public class ICanHazDadJokesModel
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }
        
        public int Limit { get; set; }
        
        [JsonProperty("next_page")]
        public int NextPage { get; set; }
        
        [JsonProperty("previous_page")]
        public int PreviousPage { get; set; }
        
        public ICanHazDadJokeModel[] Results { get; set; }
        
        [JsonProperty("search_term")]
        public string SearchTerm { get; set; }
        
        public int Status { get; set; }
        
        [JsonProperty("total_jokes")]
        public int TotalJokes { get; set; }
        
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
