using AutoMapper;
using CarsConsulting.Mappers;

namespace CarsConsulting.Tests
{
    public class BaseTest
    {
        public static IMapper GetMapper()
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.AddProfile<CarMapper>();
            });

            return config.CreateMapper();
        }
    }
}
