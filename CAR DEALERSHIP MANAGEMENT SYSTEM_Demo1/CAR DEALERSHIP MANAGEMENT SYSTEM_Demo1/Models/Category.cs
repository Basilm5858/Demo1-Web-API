using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
