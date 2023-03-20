namespace CarsConsulting.Common.DTOs
{
    public class CarEnumsDto
    {
        public Dictionary<int, string>? CylinderNumbers { get; set; }
        public Dictionary<int, string>? FuelTypes { get; set; }
        public Dictionary<int, string>? TransmissionTypes { get; set; }
    }
}
