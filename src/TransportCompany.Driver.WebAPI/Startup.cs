using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Driver.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Driver.WebAPI
{
    public class Startup: BaseStartup<Startup>
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) 
            : base(configuration, env, "Driver")
        {
        }

        protected override void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<DriverDbContext>(options => options
                .UseSqlServer(ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("TransportCompany.Driver.Infrastructure");
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));

            if (bool.Parse(Configuration["RUN_EF_MIGRATIONS"]))
            {
                var dbContext = services.BuildServiceProvider().GetService<DriverDbContext>();
                dbContext.Database.Migrate();
            }
        }

        protected override void ConfigureApplicationLayerServices(IServiceCollection services)
        {
            var applicationLayerAssembly = Assembly.Load("TransportCompany.Driver.Application");
            RegisterAllServicesScopedFromAssembly(services, applicationLayerAssembly);

            services.AddMediatR(applicationLayerAssembly);
            services.AddAutoMapper(applicationLayerAssembly);
        }

        protected override void ConfigureInfrastructureLayerServices(IServiceCollection services)
        {
            var infrastructureLayerAssembly = Assembly.GetAssembly(typeof(DriverDbContext));
            RegisterAllServicesScopedFromAssembly(services, infrastructureLayerAssembly);
        }
    }
}
