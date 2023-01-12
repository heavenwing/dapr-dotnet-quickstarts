using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWithSdk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> logger;
        private readonly IConfiguration configuration;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public string[] Get()
        {
            logger.LogInformation("Get values... by info");
            logger.LogWarning("Get values... by warn");
            return new string[] { "abc", "efg" };
        }

        [HttpPut]
        public void Put(string value)
        {
            configuration["Logging:LogLevel:Default"] = value;
        }
    }
}
