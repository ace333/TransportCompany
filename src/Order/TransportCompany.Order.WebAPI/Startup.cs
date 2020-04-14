using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Order.Infrastructure;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;

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
                    sqlServerOptions.MigrationsAssembly("TransportCompany.Order.Infrastructure");
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));

            var dbContext = services.BuildServiceProvider().GetService<OrderDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
