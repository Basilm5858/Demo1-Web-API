namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void DeleteAsync(T entity);
    }
}
