using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MassTransit;
using TransportCompany.Shared.Infrastructure.Config;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Scrutor;
using TransportCompany.Shared.Infrastructure.Model;
using TransportCompany.Shared.Domain.Services;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;

namespace TransportCompany.Shared.ApiInfrastructure
{
    public abstract class BaseStartup<TStartup> where TStartup : class
    {
        private readonly string _apiName;
        private readonly RabbitMqConfig _rabbitMqConfig;
        protected readonly IConfiguration Configuration;
        protected readonly string ConnectionString;

        protected BaseStartup(IConfiguration configuration, IHostEnvironment env, string apiName)
        {
            _apiName = $"TransportCompany {apiName} Web API";
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);

            if (env.IsProduction())
                builder.AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddJsonFile("appsettings.Development.json");


            _rabbitMqConfig = GetRabbitMqConfig();
            ConnectionString = GetConnectionString();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMassTransit(services);
            ConfigureDataContext(services);

            ConfigureInfrastructureLayerServices(services);
            ConfigureApplicationLayerServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = _apiName, Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", _apiName); });

            app.UseRouting();
            app.UseEndpoints(c => c.MapControllers());

            applicationLifetime.ApplicationStarted.Register(() => ApplicationStarted(app));
            applicationLifetime.ApplicationStopped.Register(() => ApplicationStopped(app));
        }

        protected abstract ReceiveEndpointConfig[] RegisterRabbitMqEndpoints();
        protected abstract Assembly GetApplicationLayerAssembly();
        protected abstract Assembly GetInfrastructureLayerAsembly();
        protected abstract void ConfigureDataContext(IServiceCollection services);

        private void ConfigureApplicationLayerServices(IServiceCollection services)
        {
            var applicationLayerAssembly = GetApplicationLayerAssembly();
            RegisterAllServicesScopedFromAssembly(services, applicationLayerAssembly);

            services.AddMediatR(applicationLayerAssembly);
            services.AddAutoMapper(applicationLayerAssembly);
        }

        private void ConfigureInfrastructureLayerServices(IServiceCollection services)
        {
            var infrastructureLayerAssembly = GetInfrastructureLayerAsembly();
            RegisterAllServicesScopedFromAssembly(services, infrastructureLayerAssembly);
        }

        private void RegisterAllServicesScopedFromAssembly(IServiceCollection services, Assembly assembly)
        {
            services.Scan(x => x.FromAssemblies(GetAllReferencedAssembliesWithSelf(assembly))
                .AddClasses(y => y.AssignableTo<IScopedService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(x => x.FromAssemblies(GetAllReferencedAssembliesWithSelf(assembly))
                .AddClasses(y => y.AssignableTo<ISingletonService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            services.Scan(x => x.FromAssemblies(GetAllReferencedAssembliesWithSelf(assembly))
                .AddClasses(y => y.AssignableTo<IDomainService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private void ConfigureMassTransit(IServiceCollection services)
        {
            services.ConfigureMassTransit(_rabbitMqConfig,
                    ConsumersConfiguration.AddConsumersFromAssembly(GetApplicationLayerAssembly()),
                    RegisterRabbitMqEndpoints());
        }

        private Assembly[] GetAllReferencedAssembliesWithSelf(Assembly assembly)
        {
            var assemblies = new List<Assembly> {assembly};
            assemblies.AddRange(
                assembly.GetReferencedAssemblies()
                    .Where(x => x.FullName.StartsWith("TransportCompany"))
                    .Select(Assembly.Load)
                );

            return assemblies.ToArray();
        } 

        private RabbitMqConfig GetRabbitMqConfig()
        {
            var config = new
            {
                Host = Configuration["RABBITMQ_HOST"],
                User = Configuration["RABBITMQ_USER"],
                Password = Configuration["RABBITMQ_PASSWORD"]
            };

            return new RabbitMqConfig(config.Host, config.User, config.Password);
        }

        private string GetConnectionString()
        {
            var sqlConfig = new
            {
                Server = Configuration["SQL_SERVER"],
                Username = Configuration["SQL_USERNAME"],
                Password = Configuration["SA_PASSWORD"],
                Database = Configuration["SQL_DATABASE"]
            };

            return $"Server={sqlConfig.Server};Database={sqlConfig.Database};User ID={sqlConfig.Username};Password={sqlConfig.Password};";
        }

        private Func<IApplicationBuilder, Task> ApplicationStarted => async (app) =>
        {
            var bus = app.ApplicationServices.GetService<IBusControl>();
            await bus.StartAsync();
        };

        private Func<IApplicationBuilder, Task> ApplicationStopped => async (app) =>
        {
            var bus = app.ApplicationServices.GetService<IBusControl>();
            await bus.StopAsync();
        };
    }
}