using MassTransit;
using System;

namespace TransportCompany.Shared.Infrastructure.Config
{
    public class ReceiveEndpointConfig
    {
        public static ReceiveEndpointConfig Create(string queueName,
            Func<IRegistrationContext<IServiceProvider>, Action<IReceiveEndpointConfigurator>> configurationAction)
            => new ReceiveEndpointConfig(queueName, configurationAction);

        protected ReceiveEndpointConfig(string queueName,
            Func<IRegistrationContext<IServiceProvider>, Action<IReceiveEndpointConfigurator>> configurationAction)
        {
            QueueName = queueName;
            ConfigurationAction = configurationAction;
        }

        public string QueueName { get; }
        public Func<IRegistrationContext<IServiceProvider>, Action<IReceiveEndpointConfigurator>> ConfigurationAction { get; }
    }
}
