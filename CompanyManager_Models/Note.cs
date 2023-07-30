using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager_Models
{
    public class Note
    {
        public int Id { get; set; } = 1;
        public string InvoiceNumber { get; set; }
        public string Employee { get; set; }
    }
}
