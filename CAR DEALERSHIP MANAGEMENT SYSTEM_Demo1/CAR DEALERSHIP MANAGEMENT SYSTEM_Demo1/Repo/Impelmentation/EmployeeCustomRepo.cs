using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class EmployeeCustomRepo : GenericRepo<Employee>, IEmployee
    {
        private readonly My_AppContext _context;
        public EmployeeCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeDTO>> EndPoint2()
        {
            return await _context.Employees
                .OrderBy(x => x.Sales.Count)
                .Select(x => new EmployeeDTO
                {
                    Id = x.Id,
                    SalesCount = x.Sales.Count,
                    Email = x.Email,
                    FullName = x.FullName,
                    HireDate = x.HireDate,
                    Phone = x.Phone,
                    Position = x.Position
                }).ToListAsync();
        }
    }
}
