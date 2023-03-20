using System.ComponentModel.DataAnnotations;

namespace CarsConsulting.DAL.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid? Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
