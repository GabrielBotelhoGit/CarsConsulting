using CarsConsulting.DAL;
using CarsConsulting.Repositories;
using CarsConsulting.Services;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting
{
    public partial class Startup
    {
        public void ConfigureIoc(IServiceCollection services)
        {
            services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("CarsConsultingDb")), ServiceLifetime.Singleton);

            services.AddSingleton<ICarService, CarService>();
            services.AddSingleton<IMakerService, MakerService>();

            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<IMakerRepository, MakerRepository>();
        }
    }
}
