using AutoMapper;
using CarsConsulting.DAL.Models;
using CarsConsulting.DTOs;

namespace CarsConsulting.Mappers
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<Car, CarDto>()
                .ForMember(d => d.Maker, opt => opt.MapFrom(src => src.Maker.Name))
                .ReverseMap();
        }
    }
}
