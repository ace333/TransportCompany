using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Windsor;
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

namespace TransportCompany.Shared.ApiInfrastructure
{
    public abstract class BaseStartup<TStartup> where TStartup : class
    {
        private readonly string _apiName;
        private readonly IConfiguration _configuration;
        private readonly WindsorContainer _container = new WindsorContainer();
        private readonly RabbitMqConfig _rabbitMqConfig;
        protected readonly string ConnectionString;

        protected BaseStartup(IConfiguration configuration, IHostEnvironment env, string apiName)
        {
            _apiName = $"TransportCompany {apiName} Web API";
            _configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);

            if (env.IsProduction())
                builder.AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddUserSecrets<TStartup>();

            _rabbitMqConfig = GetRabbitMqConfig();
            ConnectionString = GetConnectionString();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDataContext(services);

            ConfigureInfrastructureLayerServices(services);
            ConfigureApplicationLayerServices(services);

            //_container.ConfigureMassTransit(_rabbitMqConfig, 
            //    ConsumersConfiguration.AddConsumersFromAssemblies(GetReferencedAssemblies(assembly)),
            //    ConsumersConfiguration.RegisterConsumers(_container));

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

            //applicationLifetime.ApplicationStarted.Register(() => ApplicationStarted(app));
            //applicationLifetime.ApplicationStopped.Register(() => ApplicationStopped(app));
        }

        protected abstract void ConfigureDataContext(IServiceCollection services);
        protected abstract void ConfigureApplicationLayerServices(IServiceCollection services);
        protected abstract void ConfigureInfrastructureLayerServices(IServiceCollection services);

        protected void RegisterAllServicesScopedFromAssembly(IServiceCollection services, Assembly assembly)
        {
            services.Scan(x => x.FromAssemblies(GetAllReferencedAssembliesWithSelf(assembly))
                .AddClasses(y => y.AssignableTo<IScopedService>())
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
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
                Host = _configuration["RABBITMQ_HOST"],
                User = _configuration["RABBITMQ_USER"],
                Password = _configuration["RABBITMQ_PASSWORD"],
                QueueName = _configuration["RABBITMQ_QUEUE_NAME"]
            };

            return new RabbitMqConfig(config.Host, config.User, config.Password, config.QueueName);
        }

        private string GetConnectionString()
        {
            var sqlConfig = new
            {
                Server = _configuration["SQL_SERVER"],
                Username = _configuration["SQL_USERNAME"],
                Password = _configuration["SA_PASSWORD"],
                Database = _configuration["SQL_DATABASE"]
            };

            return $"Server={sqlConfig.Server};Database={sqlConfig.Database};User Id={sqlConfig.Username};Password={sqlConfig.Password};";
        }

        private Action<IApplicationBuilder> ApplicationStarted => (app) =>
        {
            app.ApplicationServices.GetService<IBusControl>().Start();
        };

        private Action<IApplicationBuilder> ApplicationStopped => (app) =>
        {
            app.ApplicationServices.GetService<IBusControl>().Stop();
        };
    }
}