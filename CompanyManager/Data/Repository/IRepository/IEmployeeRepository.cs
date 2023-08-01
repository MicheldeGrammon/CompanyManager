using CompanyManager.Models;

namespace CompanyManager.Data.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task UpdateAsync(Employee obj);

        Task<List<Employee>> GetAllAsync(int id);
    }
}
