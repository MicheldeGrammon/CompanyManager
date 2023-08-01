using CompanyManager.Models;
using System.ComponentModel.Design;

namespace CompanyManager.Data.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task UpdateAsync(Company obj);
    }
}