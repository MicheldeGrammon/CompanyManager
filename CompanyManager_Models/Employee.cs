using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager_Models
{
    public class Employee
    {
        public int Id { get; set; } =1;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; } = "Mr.";
        public string BirthDate { get; set; } = "3/16/1964";
        public string Position { get; set; } = "CEO";
    }
}
