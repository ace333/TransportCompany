using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Driver.Application.Base;
using TransportCompany.Driver.Application.Consumers;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Config;

namespace TransportCompany.Driver.WebAPI
{
    public class Startup : BaseStartup<Startup>
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) 
            : base(configuration, env, "Driver")
        {
        }

        protected override void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<DriverDbContext>(options => options
                .UseSqlServer(ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(DriverDbContext)).FullName);
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));

            if (bool.Parse(Configuration["RUN_EF_MIGRATIONS"]))
            {
                var dbContext = services.BuildServiceProvider().GetService<DriverDbContext>();
                dbContext.Database.Migrate();
            }
        }

        protected override ReceiveEndpointConfig[] RegisterRabbitMqEndpoints()
            => new[]
            {
                ReceiveEndpointConfig.Create(Configuration["RABBITMQ_ORDER_QUEUE_NAME"],
                    (context) =>
                        (endpointConfigurator) =>
                        {
                            endpointConfigurator.ConfigureConsumer<RideCreatedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<RideTerminatedConsumer>(context);
                        }),
                ReceiveEndpointConfig.Create(Configuration["RABBITMQ_RIDE_QUEUE_NAME"],
                    (context) =>
                        (endpointConfigurator) =>
                        {
                            endpointConfigurator.ConfigureConsumer<DriverRatedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<RideRequestedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<RouteAddedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<RouteDeletedConsumer>(context);
                        })
            };

        protected override Assembly GetApplicationLayerAssembly()
            => Assembly.GetAssembly(typeof(DriverApplicationLayerBase));

        protected override Assembly GetInfrastructureLayerAsembly()
            => Assembly.GetAssembly(typeof(DriverDbContext));
    }
}
