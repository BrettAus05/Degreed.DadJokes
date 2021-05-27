namespace Degreed.DadJokes.Web.Models
{
    public class RandomJokeViewModel
    {
        public string Id { get; set; }
        public bool Success { get; set; }
        public string Text { get; set; }
        public string ErrorMessage { get; set; }
    }
}
