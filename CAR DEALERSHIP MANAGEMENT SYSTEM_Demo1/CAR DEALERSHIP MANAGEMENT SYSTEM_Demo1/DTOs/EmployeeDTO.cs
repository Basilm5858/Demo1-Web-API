using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs
{
    public class EmployeeDTO
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
        public int SalesCount { get; set; }
    }
    public class CreateEmployeeDTO
    {
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
    }
    public class UpdateEmployeeDTO
    {
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
    }

}
