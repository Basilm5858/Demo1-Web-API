using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        CustomerCustomRepo customerCustomRepo { get; }
        VehicleCustomRepo vehicleCustomRepo { get; }
        SalesCustomRepo salesCustomRepo { get; }
        CategoryCustomRepo categoryCustomRepo { get; }
        EmployeeCustomRepo EmployeeCustomRepo { get; }
        CustomerProfileCustomRepo CustomerProfileCustomRepo { get; }

        Task SaveChangesAsync();
    }
}
