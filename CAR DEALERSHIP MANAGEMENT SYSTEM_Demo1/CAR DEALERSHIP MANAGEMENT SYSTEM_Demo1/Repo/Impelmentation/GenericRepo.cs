using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly My_AppContext _context;
        private readonly DbSet<T> db;
        public GenericRepo(My_AppContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await db.AddAsync(entity);
        }

        public void DeleteAsync(T Entity)
        {
            db.Remove(Entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await db.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.FindAsync(id);
        }
    }
}
