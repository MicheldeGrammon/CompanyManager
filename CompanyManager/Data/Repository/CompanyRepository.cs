using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Company obj)
        {
            var objFromDb = await _context.Company.FindAsync(obj.Id);
            if (objFromDb == null)
            {
                throw new ArgumentNullException($"Entity {objFromDb.GetType} not found");
            }

            objFromDb.Address = obj.Address;
            objFromDb.City = obj.City;
            objFromDb.Phone = obj.Phone;
            objFromDb.Name = obj.Name;
            objFromDb.State = obj.State;

            await _context.SaveChangesAsync();
        }      
    }
}
