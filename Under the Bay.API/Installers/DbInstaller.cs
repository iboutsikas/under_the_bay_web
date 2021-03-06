using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using Under_the_Bay.Data;
using Under_the_Bay.Data.Repositories;

namespace Under_the_Bay.API.Installers
{
    public class DbInstaller: IInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UtbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("PGSQL_DEV");
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = configuration["UTB_CONNECTION_STRING"];
                }
                
                options.UseNpgsql(connectionString, b =>
                {
                    b.MigrationsAssembly("Under the Bay.API");
                    b.UseNodaTime();
                });
            });

            services.AddScoped<IStationsRepository, StationsRepository>();
            services.AddSingleton<IClock>(SystemClock.Instance);
        }
    }
}