using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs
{
    public class EmployeeWithSalesDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
        public int TotalCarsSold { get; set; }
        public ICollection<SalesDetailsDTO> Sales { get; set; } = new List<SalesDetailsDTO>();
    }
    public class SalesDetailsDTO
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12, 2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Notes { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string EmployeeFullName { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public int VehicleMileage { get; set; }
        public string VehicleVIN { get; set; } = string.Empty;
    }
    public class SalesDTO
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12, 2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Notes { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; } = string.Empty;
        public int VehicleMileage { get; set; }
        public string VehicleVIN { get; set; } = string.Empty;


    }
    public class CreateSaleDTO
    {
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12, 2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Notes { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
    }

    public class UpdateSaleDTO
    {
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12, 2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Notes { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
    }
}
