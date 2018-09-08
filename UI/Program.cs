using CustomerApp.Core.DomainService;
using CustomerApp.Infrastructure.Static.Data.Repositories;
using CustomerApp.Core.Entity;
using System;
using System.Collections.Generic;
using BildeConsole;
using Microsoft.Extensions.DependencyInjection;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;

namespace BildeConsole
{
    class Program
    {

        
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();


        }

      
    }
}

