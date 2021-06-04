using JWT.API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace JWT.API2.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("token")]
        public async Task<AuthenticationModel> PostLogin()
        {
            TokenRequestModel tokenRequestModel = new TokenRequestModel() { Database = "Db1", UserName = "jpthomas" };

            var apiName = $"https://localhost:44318/api/User/tokenonly";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiName, tokenRequestModel);
            var jasonString = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<AuthenticationModel>
                    (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            
            return (data);
        }
    }
}
