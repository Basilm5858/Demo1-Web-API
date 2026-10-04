using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces
{
    public interface ISales : IGenericRepo<Sale>
    {
        Task<ICollection<EmployeeWithSalesDto>> GetSalesGroupedByEmployee();
    }
}
