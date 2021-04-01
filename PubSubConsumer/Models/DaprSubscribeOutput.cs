using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PubSubConsumer.Models
{
    public class DaprSubscribeOutput
    {
        [JsonPropertyName("pubsubname")]
        public string PubSubName { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        [JsonPropertyName("route")]
        public string Route { get; set; }
    }
}
