using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Employee obj)
        {
            var objFromDb = await _context.Employee.FindAsync(obj.Id);
            if (objFromDb == null)
            {
                throw new ArgumentNullException(nameof(objFromDb));
            }

            objFromDb.FirstName = obj.FirstName;
            objFromDb.LastName = obj.LastName;
            objFromDb.BirthDate = obj.BirthDate;
            objFromDb.Position = obj.Position;
            objFromDb.Title = obj.Title;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync(int id)
        {
            var allEntity = await dbSet.Where(x => x.CompanyId == id)
                                       .ToListAsync();

            if (allEntity == null)
            {
                throw new ArgumentNullException("Entities not found");
            }

            return allEntity;
        }
    }
}
