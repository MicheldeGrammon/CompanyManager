using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM(Company company, IEnumerable<History> history, IEnumerable<Note> notes, List<Employee> employees, Employee employee)
        {
            Company = company;
            History = history;
            Notes = notes;
            Employees = employees;
            Employee = employee;
        }

        public Company Company { get; set; }
        public IEnumerable<History> History { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}
