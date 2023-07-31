using CompanyManager.Models;

namespace CompanyManager.Data.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task Udate(Company obj);
    }
}