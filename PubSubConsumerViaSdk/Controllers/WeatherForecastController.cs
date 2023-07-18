using Dapr;
using Microsoft.AspNetCore.Mvc;
using PubSubConsumerViaSdk.Models;

namespace PubSubConsumerViaSdk.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("sleep")]
        [Topic("pubsub", "quickstarts/sleep", DeadLetterTopic = "poisonMessages")]
        public IActionResult Sleep(MessageInput model)
        {
            //using (var sr = new StreamReader(Request.Body))
            //{
            //    var payload = await sr.ReadToEndAsync();
            //    _logger.LogInformation(payload);
            //}
            _logger.LogInformation(model.Name);
            return BadRequest();
        }

        [HttpPost("wakeup")]
        [Topic("pubsub", "quickstarts/wakeup", DeadLetterTopic = "poisonMessages")]
        public IActionResult Wakeup(MessageInput model)
        {
            //using (var sr = new StreamReader(Request.Body))
            //{
            //    var payload = await sr.ReadToEndAsync();
            //    _logger.LogInformation(payload);
            //}
            _logger.LogInformation(model.Name);
            return Ok();
        }
    }
}