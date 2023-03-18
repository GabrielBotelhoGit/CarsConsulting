using System.ComponentModel.DataAnnotations;

namespace CarsConsulting.DAL.Models
{
    public class Maker : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public List<Car> Cars { get; set; }

        public Maker() { 
            Name = String.Empty;
            Cars = new();
        }
        public Maker(string name, List<Car> cars)
        {
            Name = name;
            Cars = cars;
        }
    }
}
