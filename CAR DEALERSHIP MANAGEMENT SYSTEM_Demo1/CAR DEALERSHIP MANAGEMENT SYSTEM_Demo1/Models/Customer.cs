using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string DriverLicenseNumber { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public CustomerProfile CustomerProfile { get; set; }

    }
}