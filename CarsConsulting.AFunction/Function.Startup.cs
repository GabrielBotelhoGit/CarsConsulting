using CarsConsulting.AFunction;
using CarsConsulting.DAL;
using CarsConsulting.Repositories;
using CarsConsulting.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace CarsConsulting.AFunction
{
    public class Startup : FunctionsStartup
    {

        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfigurationRoot configuration = SetConfigurationRoot();

            builder.Services.AddLogging(c =>
            {
                c.AddConsole();
            });

            builder.Services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarsConsultingDb")), ServiceLifetime.Singleton);


            builder.Services.AddSingleton<IMakerService, MakerService>();
            builder.Services.AddSingleton<IMakerRepository, MakerRepository>();
        }


        private IConfigurationRoot SetConfigurationRoot()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
    }
}
