using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManagement
{
    class Program
    {
        static string daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500";
        const string stateStoreName = "statestore";//default state store name
        const string stateKey = "order-17";
        static string stateUrl = $"http://localhost:{daprPort}/v1.0/state/{stateStoreName}";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Start demostrate State Management!");
            Console.WriteLine($"DAPR_HTTP_PORT is {daprPort}");

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
