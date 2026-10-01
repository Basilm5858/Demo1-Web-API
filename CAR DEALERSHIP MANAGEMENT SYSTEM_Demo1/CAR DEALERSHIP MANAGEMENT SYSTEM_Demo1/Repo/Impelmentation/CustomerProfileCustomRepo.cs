using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class CustomerProfileCustomRepo : GenericRepo<CustomerProfile>, ICustomerProfile
    {
        public CustomerProfileCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
