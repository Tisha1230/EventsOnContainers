using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) //telling startup(host) to give access to all services(dependencies)
            {
                var serviceProviders = scope.ServiceProvider; //tell me all the providers of dependency. eg of providers: SQL server, Redis cache, this case EventContext is provider
                var context = serviceProviders.GetRequiredService<EventContext>(); //give me EventContext provider. i want access to it. it makes sure EventContext is up and running
                EventSeed.Seed(context);

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
