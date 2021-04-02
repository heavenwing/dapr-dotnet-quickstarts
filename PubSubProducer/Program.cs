using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PubSubProducer
{
    class Program
    {
        static string daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "50001";
        static string daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "3500";
        const string pubsubName = "pubsub";
        const string topicName1 = "quickstarts/wakeup";
        const string topicName2 = "quickstarts/sleep";
        static string pubsubUrl = $"http://localhost:{daprHttpPort}/v1.0/publish/{pubsubName}/";

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting publish message {pubsubName}");

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(pubsubUrl);

            Console.WriteLine($"To {topicName1} ...");
            var request1 = new HttpRequestMessage(HttpMethod.Post, topicName1);
            request1.Content = new StringContent(JsonSerializer.Serialize(new { name = "Jack" }), Encoding.UTF8, "application/json");
            await httpClient.SendAsync(request1);

            Console.WriteLine($"To {topicName2} ...");
            var request2 = new HttpRequestMessage(HttpMethod.Post, topicName2);
            request2.Content = new StringContent(JsonSerializer.Serialize(new { name = "Mike" }), Encoding.UTF8, "application/json");
            await httpClient.SendAsync(request2);

            Console.WriteLine("Successfully published message.");
        }
    }
}
