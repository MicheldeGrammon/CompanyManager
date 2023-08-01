using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Data.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly DataContext _context;

        public HistoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<History>> GetAllAsync(int id)
        {
            var allEntity = await _context.History.Where(x => x.CompanyId == id)
                                                  .ToListAsync();
            if (allEntity == null)
            {
                throw new ArgumentNullException($"Entity {allEntity.GetType} not found");
            }

            return allEntity;
        }
    }
}
