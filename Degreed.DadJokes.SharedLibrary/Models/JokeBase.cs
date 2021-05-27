namespace Degreed.DadJokes.SharedLibrary.Models
{
    public abstract class JokeBase
    {
        public bool Success { get; private set; } = true;

        public string ErrorMessage { get; private set; } = string.Empty;

        public void IsError(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }
    }
}
