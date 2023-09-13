using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PubSubConsumer.Models
{
    public class TinyCloudEvent<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("pubsubname")]
        public string Pubsubname { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}
