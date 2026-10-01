using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        [Precision(12,2)]
        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;
        [MaxLength(300)]
        public string? Notes { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
