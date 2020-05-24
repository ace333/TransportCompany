using System.Reflection;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Order.Application.Base;
using TransportCompany.Order.Application.Consumers;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;
using TransportCompany.Shared.Infrastructure.Config;

namespace TransportCompany.Order.WebAPI
{
    public class Startup: BaseStartup<Startup>
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) 
            : base(configuration, env, "Order")
        {
        }

        protected override void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(options => options
                .UseSqlServer(ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(OrderDbContext)).FullName);
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));


            if (bool.Parse(Configuration["RUN_EF_MIGRATIONS"]))
            {
                var dbContext = services.BuildServiceProvider().GetService<OrderDbContext>();
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
                                endpointConfigurator.ConfigureConsumer<AvailableDriverFoundConsumer>(context);
                                endpointConfigurator.ConfigureConsumer<OrderCancelledConsumer>(context);
                                endpointConfigurator.ConfigureConsumer<RideFinishedConsumer>(context);
                            })
                };

        protected override Assembly GetApplicationLayerAssembly()
            => Assembly.GetAssembly(typeof(OrderApplicationLayerBase));

        protected override Assembly GetInfrastructureLayerAsembly()
            => Assembly.GetAssembly(typeof(OrderDbContext));
    }
}
