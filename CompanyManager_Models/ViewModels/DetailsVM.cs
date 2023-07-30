using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager_Models.ViewModels
{
    public class DetailsVM
    {
        public Company Company { get; set; }
        public IEnumerable<History> History { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
