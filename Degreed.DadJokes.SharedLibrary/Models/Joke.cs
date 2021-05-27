namespace Degreed.DadJokes.SharedLibrary.Models
{
    public class Joke : JokeBase
    {
        public Joke(string errorMessage)
        {
            IsError(errorMessage);
        }

        public Joke(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; private set; }
        
        public string Text { get; private set; }

        public int WordCount => string.IsNullOrEmpty(Text) == false ? Text.Split(' ').Length : 0;
    }
}
