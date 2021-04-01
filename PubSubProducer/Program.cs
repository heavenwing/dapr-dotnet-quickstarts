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
        const string topicName = "quickstarts";
        static string pubsubUrl = $"http://localhost:{daprHttpPort}/v1.0/publish/{pubsubName}/{topicName}";

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Starting publish message to {topicName} of {pubsubName}");

            using var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, pubsubUrl);
            request.Content = new StringContent(JsonSerializer.Serialize(new { name = "zyg" }), Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);

            Console.WriteLine("Successfully published message.");
        }
    }
}
