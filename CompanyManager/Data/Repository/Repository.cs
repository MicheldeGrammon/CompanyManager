using CompanyManager.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;
using System.Xml;

namespace CompanyManager.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        internal DbSet<T> dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity {entity.GetType} not found");
            }

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var allEntity = await dbSet.ToListAsync();
            if (allEntity == null)
            {
                throw new ArgumentNullException($"Entity {allEntity.GetType} not found");
            }

            return allEntity;
        }

        public async Task<T> FindAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity {entity.GetType} not found");
            }

            return entity;
        }
    }
}
