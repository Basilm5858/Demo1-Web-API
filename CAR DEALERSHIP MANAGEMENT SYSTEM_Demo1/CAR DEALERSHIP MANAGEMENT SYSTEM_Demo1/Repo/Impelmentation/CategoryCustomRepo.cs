using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class CategoryCustomRepo : GenericRepo<Category>, ICategory
    {
        public CategoryCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
