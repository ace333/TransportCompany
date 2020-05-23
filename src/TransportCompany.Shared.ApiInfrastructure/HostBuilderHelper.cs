using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace TransportCompany.Shared.ApiInfrastructure
{
    public class HostBuilderHelper
    {
        public static IHostBuilder CreateHostBuilder<TStartup>(string[] args) where TStartup : class
        {
            var httpPort = Environment.GetEnvironmentVariable("HTTP_PORT");

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://+:{httpPort}");
                    webBuilder.UseStartup<TStartup>();
                });
        }
    }
}
