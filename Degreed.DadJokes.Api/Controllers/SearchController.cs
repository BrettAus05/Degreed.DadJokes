using Degreed.DadJokes.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IJokesService _jokesService;

        public SearchController(ILogger<SearchController> logger, IJokesService jokesService)
        {
            _logger = logger;
            _jokesService = jokesService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string searchTerm)
        {
            var joke = await _jokesService.GetJokesBySearchTerm(searchTerm);

            if (joke.Success)
            {
                _logger.LogInformation("{TotalJokes} jokes successfully retrieved for search term {SearchTerm}", joke.TotalJokes, joke.SearchedTerm);
                return Ok(joke);
            }

            _logger.LogWarning("Unable to retrieve jokes due to error {ErrorMessage}", joke.ErrorMessage);
            return BadRequest(joke);
        }
    }
}
