using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Position { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
