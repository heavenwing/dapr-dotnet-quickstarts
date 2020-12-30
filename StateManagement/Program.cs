using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManagement
{
    class Program
    {
        static string daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "50001";
        static string daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "3500";
        const string stateStoreName = "statestore";//default state store name
        const string stateKey = "order-17";
        static string stateUrl = $"http://localhost:{daprHttpPort}/v1.0/state/{stateStoreName}";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Start demostrate State Management!");
            Console.WriteLine($"DAPR_HTTP_PORT is {daprHttpPort}");
            Console.WriteLine($"DAPR_GRPC_PORT is {daprGrpcPort}");

            using var httpClient = new HttpClient();

            Console.WriteLine("Saving state...");
            var state = new List<object>
            {
                new
                {
                    key = stateKey,
                    value = new Order
                    {
                        Id = 17,
                        Amount = 1
                    }
                }
            };
            var request = new HttpRequestMessage(HttpMethod.Post, stateUrl);
            request.Content = new StringContent(JsonSerializer.Serialize(state));
            var response = await httpClient.SendAsync(request);
            Console.WriteLine("Successfully saved state.");

            Console.WriteLine("Getting state...");
            request = new HttpRequestMessage(HttpMethod.Get, $"{stateUrl}/{stateKey}");
            response = await httpClient.SendAsync(request);
            Console.WriteLine($"Respone content: {await response.Content?.ReadAsStringAsync()}");
            Console.WriteLine("Successfully got state.");

            Console.WriteLine("Deleting state...");
            request = new HttpRequestMessage(HttpMethod.Delete, $"{stateUrl}/{stateKey}");
            response = await httpClient.SendAsync(request);
            Console.WriteLine("Successfully deleted state.");
        }
    }
}
