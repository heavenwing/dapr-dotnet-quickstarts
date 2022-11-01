// See https://aka.ms/new-console-template for more information
using Dapr.Client;

Console.WriteLine("Hello, World!");

string SECRET_STORE_NAME = "localsecretstore";
//string SECRET_STORE_NAME = "azurekeyvault";
using var client = new DaprClientBuilder().Build();
//Using Dapr SDK to get a secret
var secret = await client.GetSecretAsync(SECRET_STORE_NAME, "secret");
//var secret = await client.GetSecretAsync(SECRET_STORE_NAME, "cae-connstr");
Console.WriteLine($"Result has {secret.Count} item(s)");
Console.WriteLine($"Result has key {secret.Keys.First()}");
Console.WriteLine($"Result has value {secret.Values.First()}");
Console.WriteLine($"Result: {string.Join(", ", secret)}");
