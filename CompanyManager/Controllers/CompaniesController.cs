using CompanyManager.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using CompanyManager.Models;

namespace CompanyManager.Controllers
{
    public class CompaniesController : Controller
    {
        List<Company> Companies = new List<Company>()
        {
            new Company ("Super Mart of the West","Bentonville", "Arkansas","(800) 555-2797"),
            new Company("Electronics Deport","Atlanta", "Georgia","(800) 595-3232"),
            new Company("K&S Music","Minneapolis", "Minnesota","(612) 304-6073"),
            new Company("Tom's Club","Issaquah", "Washington","(800) 955-2292"),
            new Company("E-Mart","Hoffman Estates", "Illinois","(847) 286-2500"),
            new Company("Walters","Dreefield", "Illinois","(847) 940-2500"),
            new Company("StereoShack", "Fort Worth", "Texas", "(817) 820-0741"),
            new Company("Circuit Town", "Oak Brook", "Illinois", "(800) 955-2929"),
            new Company("Premier Buy", "Richfield", "Minnesota", "(612) 291-1000"),
            new Company("ElectrixMax","Naperville", "Illinois", "(630) 438-7800"),
            new Company("Video Emporioum" , "Dallas", "Texas", "(214 864-3000)"),
            new Company("Screen Shop", "Mooresville", "Noth Carolina", "(800) 455-6937")
        };

        public IActionResult Index()
        {

            return View(Companies);
        }




        public IActionResult Details()
        {
            var company = Companies[0];

            var history = new History() { OrderDate = "11/12/2013", StoreCity = "Las Vegas" };
            var history2 = new History() { OrderDate = "06/11/2014", StoreCity = "Moscow" };
            var allHistory = new List<History>() { history, history2, history, history2, history, history2, history, history2, history, history2 };


            var note = new Note() { InvoiceNumber = "35703", Employee = "Harv Mudd" };
            var notes = new List<Note>() { note, note, note };

            var employee = new Employee() { FirstName = "John", LastName = "Heart" };
            var employees = new List<Employee>() { employee, employee, employee, employee, employee, employee, employee, employee, employee };

            var detailsVM = new DetailsVM() { Employees = employees, Company=company, History = allHistory, Notes = notes };

            return View(detailsVM);
        }
    }
}
