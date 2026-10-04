using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces
{
    public interface IVehicle : IGenericRepo<Vehicle>
    {
        Task<ICollection<VehicleDTO>> EndPoint2();
    }
}
