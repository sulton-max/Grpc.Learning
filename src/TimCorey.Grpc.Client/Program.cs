using System.Text.Json;
using Grpc.Net.Client;
using Grpc.Server;
using TimCorey.Grpc.Server;

var input = new HelloRequest
{
    Name = "Max"
};
var channel = GrpcChannel.ForAddress("https://localhost:7195");
var greaterService = new Greeter.GreeterClient(channel);
var customerService = new Customer.CustomerClient(channel);

//var greetingReply = await greaterService.SayHelloAsync(input);
//Console.WriteLine(greetingReply.Message);

//var customerReply = await customerService.GetCustomerInfoAsync(new CustomerLooupModel { UserId = 2 });
//Console.WriteLine(JsonSerializer.Serialize(customerReply));

CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
using (var getCustomerResponse = customerService.GetNewCustomers(new NewCustomerRequest()))
{
    while(await getCustomerResponse.ResponseStream.MoveNext(cts.Token))
    {
        var currentCustomer = getCustomerResponse.ResponseStream.Current;
        Console.WriteLine(JsonSerializer.Serialize(currentCustomer));
    }
}

Console.ReadLine();