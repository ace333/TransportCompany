using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace TransportCompany.Shared.ApiInfrastructure
{
    public class HostBuilderHelper
    {
        public static IHostBuilder CreateHostBuilder<TStartup>(string[] args) where TStartup : class
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var httpPort = Environment.GetEnvironmentVariable("HTTP_PORT");

            if (environment == Environments.Development)
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Development.json", optional: false)
                    .Build();
                httpPort = config["HTTP_PORT"];
            }            

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://+:{httpPort}");
                    webBuilder.UseStartup<TStartup>();
                });
        }
    }
}
