using CarsConsulting.Enums;

namespace CarsConsulting.DTOs
{
    public class CarDto
    {
        public string? Model { get; set; }

        public string? Maker { get; set; }

        public FuelType DriveType { get; set; }

        public CylinderNumber CylinderNumber { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public byte[]? Image { get; set; }

        public string? Year { get; set; }
    }
}
