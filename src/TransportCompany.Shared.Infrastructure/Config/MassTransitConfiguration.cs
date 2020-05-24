using System;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace TransportCompany.Shared.Infrastructure.Config
{
    public static class MassTransitConfiguration
    {
        public static void ConfigureMassTransit(this IServiceCollection services, 
            RabbitMqConfig rabbitMqConfig,
            Action<IServiceCollectionConfigurator> consumersAdditionAction, 
            params ReceiveEndpointConfig[] receiveEndpointConfigs)
        {
            services.AddMassTransit(cfg =>
            {
                consumersAdditionAction.Invoke(cfg);
                cfg.AddBus(busCfg => Bus.Factory.CreateUsingRabbitMq(x =>
                {
                    x.Host(rabbitMqConfig.Host, rabbitCfg =>
                    {
                        rabbitCfg.Username(rabbitMqConfig.User);
                        rabbitCfg.Password(rabbitMqConfig.Password);
                    });

                    foreach(var config in receiveEndpointConfigs)
                    {
                        x.ReceiveEndpoint(config.QueueName, config.ConfigurationAction(busCfg));
                    }
                }));
            });
        }
    }
}
