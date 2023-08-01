using CompanyManager.Models;

namespace CompanyManager.Data.Repository.IRepository
{
    public interface IHistoryRepository
    {
        Task<List<History>> GetAllAsync(int id);
    }
}