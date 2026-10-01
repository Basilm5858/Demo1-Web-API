using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Make { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Model { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Precision(12, 2)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage must be greater than or equal to 0")]
        public int Mileage { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; } = string.Empty;
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [MaxLength(30)]
        public string? Transmission { get; set; }
        [Required]
        public string Status { get; set; } = "Available";
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Sale Sale { get; set; }
    }
}