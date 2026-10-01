using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class UnitOfWork : IUnitOfWork
    {
        public CustomerCustomRepo customerCustomRepo { get; }

        public VehicleCustomRepo vehicleCustomRepo { get; }

        public SalesCustomRepo salesCustomRepo { get; }

        public CategoryCustomRepo categoryCustomRepo { get; }

        public EmployeeCustomRepo EmployeeCustomRepo { get; }

        public CustomerProfileCustomRepo CustomerProfileCustomRepo { get; }
        private readonly My_AppContext _context;
        public UnitOfWork(CustomerCustomRepo customerCustomRepo, VehicleCustomRepo vehicleCustomRepo, SalesCustomRepo salesCustomRepo, CategoryCustomRepo categoryCustomRepo, EmployeeCustomRepo employeeCustomRepo, CustomerProfileCustomRepo customerProfileCustomRepo, My_AppContext my_AppContext)
        {
            this.customerCustomRepo = customerCustomRepo;
            this.vehicleCustomRepo = vehicleCustomRepo;
            this.salesCustomRepo = salesCustomRepo;
            this.categoryCustomRepo = categoryCustomRepo;
            EmployeeCustomRepo = employeeCustomRepo;
            CustomerProfileCustomRepo = customerProfileCustomRepo;
            _context = my_AppContext;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
