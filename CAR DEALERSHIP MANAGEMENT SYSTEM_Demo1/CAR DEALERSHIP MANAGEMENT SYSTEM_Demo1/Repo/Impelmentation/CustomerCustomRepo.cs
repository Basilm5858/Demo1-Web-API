using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.DTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class CustomerCustomRepo : GenericRepo<Customer>, ICustomer
    {
        private readonly My_AppContext _context;
        public CustomerCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public Task<ICollection<CustomerDetailDto>> EndPoint2()
        {
            throw new NotImplementedException();
        }
    }
}
