using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PubSubConsumer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WakeupController : ControllerBase
    {
        private readonly ILogger<WakeupController> _logger;

        public WakeupController(ILogger<WakeupController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> PostAsync(TinyCloudEvent<MessageInput> model)
        {
            //using (var sr = new StreamReader(Request.Body))
            //{
            //    var payload = await sr.ReadToEndAsync();
            //    _logger.LogInformation(payload);
            //}
            _logger.LogInformation($"name: {model.Data.Name} source: {model.Source}");
            return Ok();
        }
    }
}
