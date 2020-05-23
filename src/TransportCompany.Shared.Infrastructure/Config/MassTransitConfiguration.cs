using System;
using Castle.Windsor;
using MassTransit;
using MassTransit.WindsorIntegration;

namespace TransportCompany.Shared.Infrastructure.Config
{
    public static class MassTransitConfiguration
    {
        public static void ConfigureMassTransit(this IWindsorContainer container, RabbitMqConfig rabbitMqConfig,
            Action<IWindsorContainerConfigurator> consumersAdditionAction, 
            Action<IReceiveEndpointConfigurator> receiveEndpointConfigurationAction)
        {
            container.AddMassTransit(cfg =>
            {
                consumersAdditionAction.Invoke(cfg);
                cfg.AddBus(busCfg => Bus.Factory.CreateUsingRabbitMq(x =>
                {
                    x.Host(rabbitMqConfig.Host, rabbitCfg =>
                    {
                        rabbitCfg.Username(rabbitMqConfig.User);
                        rabbitCfg.Password(rabbitMqConfig.Password);
                    });

                    x.ReceiveEndpoint(rabbitMqConfig.QueueName,
                        receiveEndpointConfigurationAction);
                }));
            });
        }
    }
}
