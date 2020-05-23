using MassTransit;
using MassTransit.WindsorIntegration;
using System;
using System.Reflection;
using Castle.Windsor;

namespace TransportCompany.Shared.Infrastructure.Config
{
    public static class ConsumersConfiguration
    {
        public static Action<IWindsorContainerConfigurator> AddConsumersFromAssemblies(Assembly[] assemblies)
            => windsorContainerConfigurator => windsorContainerConfigurator.AddConsumers(assemblies);

        public static Action<IReceiveEndpointConfigurator> RegisterConsumers(IWindsorContainer container)
            => (receiveEndpointConfigurator) =>
                receiveEndpointConfigurator.ConfigureConsumers(container);
    }
}
