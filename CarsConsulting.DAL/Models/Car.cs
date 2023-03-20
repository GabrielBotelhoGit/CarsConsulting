using CarsConsulting.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace CarsConsulting.DAL.Models
{
    public class Car : BaseEntity
    {
        
        public string Model { get; set; }

        [Required]
        public Maker? Maker { get; set; }
        
        public FuelType DriveType { get; set; }

        public CylinderNumber CylinderNumber { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public byte[]? Image { get; set; }

        public string Year { get; set; }

        public Car()
        {
            Model = string.Empty;
            Image = Array.Empty<byte>();
            Year = string.Empty;
        }
    }
}
