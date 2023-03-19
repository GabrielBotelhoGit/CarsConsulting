using CarsConsulting.Common.Validator;
using FluentValidation;

namespace CarsConsulting
{
    public partial class Startup
    {
        public void ConfigureFluentValidator(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CarDtoValidator>();
        }
    }
}
