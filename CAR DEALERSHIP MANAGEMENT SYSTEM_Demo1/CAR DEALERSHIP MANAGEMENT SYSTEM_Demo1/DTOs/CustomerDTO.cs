using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs
{

    public class CustomerDTO
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
    }
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DriverLicenseNumber { get; set; } = string.Empty;

        public CustomerProfileDto? Profile { get; set; }

        public int TotalVehicles { get; set; }
        public decimal TotalMoneySpent { get; set; }

        public ICollection<PurchaseHistoryDto> PurchaseHistory { get; set; } = new List<PurchaseHistoryDto>();
    }

    public class CustomerProfileDto
    {
        public string Address { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class PurchaseHistoryDto
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public VehicleSummaryDto Vehicle { get; set; } = null!;
    }

    public class VehicleSummaryDto
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string? Color { get; set; }
        public string VIN { get; set; } = string.Empty;
    }
    public class CreateCustomerDTO
    {
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
    }

    public class UpdateCustomerDTO
    {
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
    }
    public class EndPoint2CustomerDTO
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

    }
}
