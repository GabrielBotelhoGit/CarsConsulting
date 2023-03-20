using System.ComponentModel.DataAnnotations;

namespace CarsConsulting.DAL.Models
{
    public class Maker : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public List<Car> Cars { get; set; }

        public Maker() { 
            Name = String.Empty;
            Cars = new();
        }

        public Maker(string name)
        {
            Name = name;
            Cars = new();
        }

        public Maker(string name, List<Car> cars)
        {
            Name = name;
            Cars = cars;
        }
    }
}
