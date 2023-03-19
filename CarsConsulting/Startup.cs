using CarsConsulting.DAL;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting
{
    public partial class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddFluentValidationAutoValidation();

            ConfigureIoc(services);
            ConfigureFluentValidator(services);
        }

        public void Configure(IApplicationBuilder app, MainDbContext? mainDbContext, ILogger<Startup>? logger)
        {
            if (mainDbContext != null && logger != null)
            {
                IEnumerable<string> pedingMigrations = mainDbContext.Database.GetPendingMigrations();
                if (pedingMigrations.Any())
                {
                    logger.LogTrace("Running new migrations");
                    mainDbContext.Database.Migrate();
                }
            }          

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
