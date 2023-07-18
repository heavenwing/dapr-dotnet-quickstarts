using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PubSubConsumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubConsumer.Controllers
{
    [Route("dapr/subscribe")]
    [ApiController]
    public class DaprSubscribeController : ControllerBase
    {
        public ActionResult<DaprSubscribeOutput[]> Get()
        {
            return Ok(new DaprSubscribeOutput[]
            {
                new DaprSubscribeOutput
                {
                    PubSubName="pubsub",
                    Topic="quickstarts/wakeup",
                    Route="/api/wakeup",
                    DeadLetterTopic="poisonMessages"
                },
                new DaprSubscribeOutput
                {
                    PubSubName="pubsub",
                    Topic="quickstarts/sleep",
                    Route="/api/sleep",
                    DeadLetterTopic="poisonMessages"
                }
            });
        }
    }
}
