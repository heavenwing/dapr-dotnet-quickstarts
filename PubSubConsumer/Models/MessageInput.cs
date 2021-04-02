using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PubSubConsumer.Models
{
    public class MessageInput
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
