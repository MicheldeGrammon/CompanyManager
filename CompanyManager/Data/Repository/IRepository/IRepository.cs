namespace CompanyManager.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task RemoveAsync(int id);
    }
}