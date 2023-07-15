using System;
using System.Net.Mail;
using Grpc.Core;
using Grpc.Server;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimCorey.Grpc.Server.DataAccess;

namespace TimCorey.Grpc.Server.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> customerService;
        private readonly DataSource dataSource;

        public CustomerService(ILogger<CustomerService> customerService, DataSource dataSource)
        {
            this.customerService = customerService;
            this.dataSource = dataSource;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLooupModel request, ServerCallContext context)
        {
            var customer = dataSource.Customers.FirstOrDefault(customer => customer.Id == request.UserId);
            return customer is not null ? Task.FromResult(new CustomerModel
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                IsAlive = customer.IsAlive,
                Age = customer.Age,
            }) : Task.FromResult<CustomerModel>(null);
        }

        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            var customers = dataSource.Customers.Chunk(10).First();
            foreach (var customer in customers)
            {
                await Task.Delay(3000);

                await responseStream.WriteAsync(new CustomerModel
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    EmailAddress = customer.EmailAddress,
                    IsAlive = customer.IsAlive,
                    Age = customer.Age,
                });
            }

            //var tasks = dataSource.Customers.Chunk(10).First().ToList().Select(async customer =>
            //{
              
            //});

            //return Task.WhenAll(tasks);
        }
    }
}
