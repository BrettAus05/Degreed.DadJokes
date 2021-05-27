namespace Degreed.DadJokes.Core.ICanHazDadJoke
{
    public class ICanHazDadJokeSettings
    {
        public int MaxResults { get; set; }
        public string Uri { get; set; }
        public string RandomJokeEndpoint { get; set; }
        public string SearchJokeEndpoint { get; set; }
    }
}
