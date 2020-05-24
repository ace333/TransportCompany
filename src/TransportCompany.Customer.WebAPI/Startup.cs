using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Customer.Application.Base;
using TransportCompany.Customer.Application.Consumers;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Config;

namespace TransportCompany.Customer.WebAPI
{
    public class Startup : BaseStartup<Startup>
    {       
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
            : base(configuration, env, "Customer")
        {
        }

        protected override void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(options => options
                .UseSqlServer(ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(CustomerDbContext)).FullName);
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));

            if (bool.Parse(Configuration["RUN_EF_MIGRATIONS"]))
            {
                var dbContext = services.BuildServiceProvider().GetService<CustomerDbContext>();
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
                            endpointConfigurator.ConfigureConsumer<OrderCreatedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<OrderCompletedConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<RideTerminatedConsumer>(context);
                            
                        }),
                ReceiveEndpointConfig.Create(Configuration["RABBITMQ_RIDE_QUEUE_NAME"], 
                    (context) =>
                        (endpointConfigurator) =>
                        {
                            endpointConfigurator.ConfigureConsumer<CustomerPickedUpConsumer>(context);
                            endpointConfigurator.ConfigureConsumer<CustomerRatedConsumer>(context);
                        })
            };

        protected override Assembly GetApplicationLayerAssembly()
            => Assembly.GetAssembly(typeof(CustomerApplicationLayerBase));

        protected override Assembly GetInfrastructureLayerAsembly()
            => Assembly.GetAssembly(typeof(CustomerDbContext));
    }
}
