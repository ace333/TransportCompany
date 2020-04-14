using System;
using System.Linq;
using System.Reflection;
using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MassTransit;
using MediatR;
using TransportCompany.Shared.Infrastructure.Attributes;
using TransportCompany.Shared.Infrastructure.Config;
using Microsoft.AspNetCore.Hosting;

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
            var assembly = typeof(TStartup).Assembly;

            _container.AddFacility<AspNetCoreFacility>(x => x.CrossWiresInto(services));
            _container.Register(Classes.FromAssemblyInThisApplication(assembly)
                .Where(x => x.IsPublic && !HasConsumerAttribute(x))
                .WithServiceAllInterfaces()
                .LifestyleScoped());

            //_container.ConfigureMassTransit(_rabbitMqConfig, 
            //    ConsumersConfiguration.AddConsumersFromAssemblies(GetReferencedAssemblies(assembly)),
            //    ConsumersConfiguration.RegisterConsumers(_container));

            services.AddMediatR(assembly);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = _apiName, Version = "v1" }); });
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            ConfigureDataContext(services);
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

        private Assembly[] GetReferencedAssemblies(Assembly assembly)
            => assembly.GetReferencedAssemblies().Select(Assembly.Load).ToArray();

        private bool HasConsumerAttribute(Type type) =>
            type.GetCustomAttributes(typeof(ConsumerAttribute), true).Length > 0;

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