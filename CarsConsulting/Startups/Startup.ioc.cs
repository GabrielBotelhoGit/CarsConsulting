using CarsConsulting.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarsConsulting
{
    public partial class Startup
    {
        public void ConfigureIoc(IServiceCollection services)
        {
            services.AddDbContext<MainDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("CarsConsultingDb"));
            });
        }
    }
}
