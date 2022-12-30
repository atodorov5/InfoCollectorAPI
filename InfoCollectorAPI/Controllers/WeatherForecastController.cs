using InfoCollectorAPI.Models;
using InfoCollectorAPI.MongoDB;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace InfoCollectorAPI.Controllers
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
        private readonly IMongoRepository<User> _computerRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMongoRepository<User> computerRepository)
        {
            _logger = logger;
            _computerRepository = computerRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            var res = await _computerRepository.FindOneAsync(x => x.Username == "Admin");
            return res.Password;
        }

        [HttpPost(Name = "GetUser")]
        public async Task<string> GetUser()
        {
            /*
            var client = new RestClient("https://data.mongodb-api.com/app/data-usbvz/endpoint/data/v1/action/findOne");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Access-Control-Request-Headers", "*");
            request.AddHeader("api-key", "EtHZttnynKo8uwhVNemQcW3aRuNzioZcC8azPsdES0X4vUip9BsizfY14pa3IV4z");
            var body = @"{" + "" +@" ""collection"":""Users""," + "" +@" ""database"":""CollectedInfo""," + "" +@" ""dataSource"":""Cluster-Info-Collector""," + "" + @" ""projection"":{""Username"": ""Admin"", }" + "" +@"" + "" +@"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.PostAsync(request);
            Console.WriteLine(response.Content);

            return response.Content;
            */

            return "o";
        }
    }
}