using CarsConsulting.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting
{
    public partial class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public void Configureservices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddControllers();

            services.AddSwaggerGen();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            ConfigureIoc(services);
            //services.Configure<ForwardedHeadersOptions>(options => { });
        }

        public void Configure(IApplicationBuilder app, MainDbContext mainDbContext, ILogger<Startup> logger)
        {
            IEnumerable<string> pedingMigrations = mainDbContext.Database.GetPendingMigrations();
            if (pedingMigrations.Any())
            {
                mainDbContext.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

        }
    }
}
