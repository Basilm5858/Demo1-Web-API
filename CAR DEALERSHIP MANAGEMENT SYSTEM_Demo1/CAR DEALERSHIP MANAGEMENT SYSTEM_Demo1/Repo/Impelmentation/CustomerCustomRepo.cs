using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class CustomerCustomRepo : GenericRepo<Customer>, ICustomer
    {
        public CustomerCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
