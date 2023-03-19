using CarsConsulting.DTOs;
using FluentValidation;

namespace CarsConsulting.Common.Validator
{
    public class CarDtoValidator : AbstractValidator<CarDto>
    {
        public CarDtoValidator()
        {
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Maker).NotEmpty();
            RuleFor(X => X.CylinderNumber).NotNull();
            RuleFor(x => x.TransmissionType).NotNull();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.DriveType).NotNull();
            RuleFor(x => x.Year)
                .NotEmpty()
                .Must(x => Convert.ToInt32(x) >= 2000)
                .WithMessage("Year cannot be empty and must be bigger than 2000");
        }
    }
}
