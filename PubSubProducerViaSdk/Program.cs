using Dapr.Client;

const string pubsubName = "pubsub";
const string topicName1 = "quickstarts/wakeup";
const string topicName2 = "quickstarts/sleep";

var daprClient = new DaprClientBuilder().Build();
Console.WriteLine($"Starting publish message to: {pubsubName}");

Console.WriteLine($"To topic: {topicName1} ...");
daprClient.PublishEventAsync(pubsubName, topicName1, new { name = "Jack" }).Wait();

Console.WriteLine($"To topic: {topicName2} ...");
daprClient.PublishEventAsync(pubsubName, topicName2, new { name = "Mike" }).Wait();

Console.WriteLine("Successfully published message.");