using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class SalesCustomRepo : GenericRepo<Sale>, ISales
    {
        private readonly My_AppContext _context;
        public SalesCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ICollection<EmployeeWithSalesDto>> GetSalesGroupedByEmployee()
        {
            return await _context.Sales
              .Include(s => s.Employee)
              .Include(s => s.Customer)
              .Include(s => s.Vehicle)
              .GroupBy(s => new { s.Employee.Id, s.Employee.FullName })
              .Select(g => new EmployeeWithSalesDto
              {
                  EmployeeId = g.Key.Id,
                  EmployeeName = g.Key.FullName,
                  TotalRevenue = g.Sum(s => s.SalePrice),
                  TotalCarsSold = g.Count(),
                  Sales = g.Select(s => new SalesDetailsDTO
                  {
                      SaleId = s.Id,
                      SaleDate = s.SaleDate,
                      SalePrice = s.SalePrice,
                      PaymentMethod = s.PaymentMethod,
                      CustomerFullName = s.Customer.FullName,
                      EmployeeFullName = s.Employee.FullName,
                      Notes = s.Notes,
                      VehicleMileage = s.Vehicle.Mileage,
                      VehicleModel = s.Vehicle.Model,
                      VehicleVIN = s.Vehicle.VIN
                      
                  }).ToList()
              })
              .ToListAsync();
        }
    }
}
