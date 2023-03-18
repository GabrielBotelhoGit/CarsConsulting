using CarsConsulting.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace CarsConsulting.DAL.Models
{
    public class Car : EntityBase
    {
        
        public string Model { get; set; }        

        public Maker Maker { get; set; }
        
        public FuelType DriveType { get; set; }

        public CylinderNumber CylinderNumber { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public Car()
        {
            Model = string.Empty;
            Maker = new Maker();
        }
    }
}
