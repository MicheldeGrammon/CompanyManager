using CompanyManager.Models;

namespace CompanyManager.Data.Repository.IRepository
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<List<Note>> GetAllAsync(int id);
    }
}
