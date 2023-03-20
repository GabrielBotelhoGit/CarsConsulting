using CarsConsulting.Common.Converter;
using CarsConsulting.Enums;
using System.Text.Json.Serialization;

namespace CarsConsulting.DTOs
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string? Model { get; set; }

        public string? Maker { get; set; }

        public FuelType DriveType { get; set; }

        public CylinderNumber CylinderNumber { get; set; }

        public TransmissionType TransmissionType { get; set; }

        [JsonConverter(typeof(JsonToByteArrayConverter))]
        public byte[]? Image { get; set; }

        public string? Year { get; set; }
    }
}
