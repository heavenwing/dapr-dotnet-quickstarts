using Dapr.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StateManagementWithSdk
{
    class Program
    {
        const string stateStoreName = "statestore";//default state store name
        const string stateKey = "order-17";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Start demostrate State Management with SDK!");

            using var client = new DaprClientBuilder().Build();

            Console.WriteLine("Saving state...");
            var state = new Order
            {
                Id = 17,
                Amount = 1
            };
            await client.SaveStateAsync(stateStoreName, stateKey, state);
            Console.WriteLine("Successfully saved state.");

            Console.WriteLine("Getting state...");
            var result = await client.GetStateAsync<Order>(stateStoreName, stateKey);
            Console.WriteLine($"Order's amount is : {result.Amount}");
            Console.WriteLine("Successfully got state.");

            Console.WriteLine("Deleting state...");
            await client.DeleteStateAsync(stateStoreName, stateKey);
            Console.WriteLine("Successfully deleted state.");
        }
    }
}
