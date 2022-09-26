using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfigurationApi.Controllers
{
    [ApiController]
    [Route("configuration")]
    [Obsolete]
    public class ConfigurationController : ControllerBase
    {
        private ILogger<ConfigurationController> logger;
        private IConfiguration configuration;
        private DaprClient client;

        public ConfigurationController(ILogger<ConfigurationController> logger, IConfiguration configuration, [FromServices] DaprClient client)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.client = client;
        }

        [HttpGet("get/{configStore}/{queryKey}")]
        public async Task GetConfiguration([FromRoute] string configStore, [FromRoute] string queryKey)
        {
            logger.LogInformation($"Querying Configuration with key: {queryKey}");
            var configItems = await client.GetConfiguration(configStore, new List<string>() { queryKey });

            if (configItems.Items.Count == 0)
            {
                logger.LogInformation($"No configuration item found for key: {queryKey}");
            }

            foreach (var item in configItems.Items)
            {
                logger.LogInformation($"Got configuration item:\nKey: {item.Key}\nValue: {item.Value}\nVersion: {item.Version}");
            }
        }

        [HttpGet("extension")]
        public Task SubscribeAndWatchConfiguration()
        {
            logger.LogInformation($"Getting values from Configuration Extension, watched values ['withdrawVersion', 'source'].");

            logger.LogInformation($"'withdrawVersion' from extension: {configuration["withdrawVersion"]}");
            logger.LogInformation($"'source' from extension: {configuration["source"]}");

            return Task.CompletedTask;
        }
    }
}
