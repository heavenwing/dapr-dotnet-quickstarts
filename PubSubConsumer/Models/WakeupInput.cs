using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PubSubConsumer.Models
{
    public class WakeupInput
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
