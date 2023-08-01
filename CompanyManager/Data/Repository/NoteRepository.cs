using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Data.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(DataContext context) : base(context)  { }

        public async Task<List<Note>> GetAllAsync(int id)
        {
                var allEntity = await dbSet.Where(x => x.CompanyId == id)
                                           .ToListAsync();

                if (allEntity == null)
                {
                    throw new ArgumentNullException($"Entity {allEntity.GetType} not found");
                }

                return allEntity;
        }
    }
}
