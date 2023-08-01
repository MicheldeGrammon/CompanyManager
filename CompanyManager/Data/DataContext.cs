using CompanyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Note> Note { get; set; }

    }
}
