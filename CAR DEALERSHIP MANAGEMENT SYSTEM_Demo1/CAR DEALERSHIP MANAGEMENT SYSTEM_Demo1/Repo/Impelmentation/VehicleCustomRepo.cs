using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class VehicleCustomRepo : GenericRepo<Vehicle>, IVehicle
    {
        private readonly My_AppContext _context;
        public VehicleCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<VehicleDTO>> EndPoint2()
        {
            return await _context.Vehicles
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Price)
                .Select(v => new VehicleDTO
                {
                    Id = v.Id,
                    Make = v.Make,
                    Model = v.Model,
                    Year = v.Year,
                    Price = v.Price,
                    Status = v.Status,
                    CategoryId = v.CategoryId,
                    CategoryName = v.Category.Name,
                })
                .ToListAsync();
        }
    }
}
