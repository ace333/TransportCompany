using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransportCompany.Customer.Infrastructure.Persistence;
using TransportCompany.Shared.ApiInfrastructure;

namespace TransportCompany.Customer.WebAPI
{
    public class Startup : BaseStartup<Startup>
    {       
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
            : base(configuration, env, "Customer")
        {
        }

        protected override void ConfigureDataContext(IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(options => options
                .UseSqlServer(ConnectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("TransportCompany.Customer.Infrastructure");
                    sqlServerOptions.EnableRetryOnFailure(5);
                }));

            var dbContext = services.BuildServiceProvider().GetService<CustomerDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
