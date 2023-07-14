using Grpc.Net.Client;
using TimCorey.Grpc.Server;

var input = new HelloRequest
{
    Name = "Max"
};
var channel = GrpcChannel.ForAddress("https://localhost:7195");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply.Message);

