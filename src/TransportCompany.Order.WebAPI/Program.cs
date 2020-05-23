using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Order.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            HostBuilderHelper.CreateHostBuilder<Startup>(args);
    }
}
