using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;

namespace CompanyManager.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task UdateAsync(Company obj)
        {
            var objFromDb = await _context.Company.FindAsync(obj.Id);
            if (objFromDb == null)
            {
                throw new ArgumentNullException(nameof(objFromDb));
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
