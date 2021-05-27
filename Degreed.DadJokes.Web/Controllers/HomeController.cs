using Degreed.DadJokes.Web.Models;
using Degreed.DadJokes.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Degreed.DadJokes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static IDadJokesHttpClient _httpClient;
        private readonly WebSettings _settings;

        public HomeController(ILogger<HomeController> logger, IDadJokesHttpClient httpClient, WebSettings settings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            var connected = await _httpClient.Connected();
            var indexModel = new IndexViewModel
            {
                Connected = connected,
                LocalHost = _settings.ApiUri
            };
            return View(indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> RandomJoke()
        {
            var jokeModel = await _httpClient.GetRandomJoke();

            return View(jokeModel);
        }

        public async Task<IActionResult> SearchJokes(string searchTerm)
        {
            var jokesModel = await _httpClient.SearchJokes(searchTerm);

            return View(jokesModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
