using MassTransit;
using System;
using System.Reflection;
using MassTransit.ExtensionsDependencyInjectionIntegration;

namespace TransportCompany.Shared.Infrastructure.Config
{
    public static class ConsumersConfiguration
    {
        public static Action<IServiceCollectionConfigurator> AddConsumersFromAssembly(Assembly assembly)
            => configurator => configurator.AddConsumers(assembly);
    }
}
