using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Degreed.DadJokes.Core.Services;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly ILogger<JokeController> _logger;
        private readonly IJokesService _jokesService;

        public JokeController(ILogger<JokeController> logger, IJokesService jokesService)
        {
            _logger = logger;
            _jokesService = jokesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var joke = await _jokesService.GetRandomJoke();

            if (joke.Success)
            {
                _logger.LogInformation("Jokes {Id} successfully retrieved", joke.Id);
                return Ok(joke);
            }

            _logger.LogWarning("Unable to retrieve a joke due to error {ErrorMessage}", joke.ErrorMessage);
            return BadRequest(joke);
        }
    }
}
