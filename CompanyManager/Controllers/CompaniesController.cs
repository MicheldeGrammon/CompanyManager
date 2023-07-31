using CompanyManager.Models.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using CompanyManager.Models;
using CompanyManager.Data.Repository.IRepository;

namespace CompanyManager.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepo;

        public CompaniesController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }


        public async Task<IActionResult> Index()
        {
            var companies = await _companyRepo.GetAllAsync();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company obj)
        {
            _companyRepo.Add(obj);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var obj = await _companyRepo.FindAsync(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            await _companyRepo.Remove(id);

            return RedirectToAction("Index");
        }








        public IActionResult Details()
        {
            var company = new Company();

            var history = new History();
            var history2 = new History();
            var allHistory = new List<History>() { history, history2, history, history2, history, history2, history, history2, history, history2 };


            var note = new Note() { InvoiceNumber = "35703", Employee = "Harv Mudd" };
            var notes = new List<Note>() { note, note, note };

            var employee = new Employee() { FirstName = "John", LastName = "Heart" };
            var employees = new List<Employee>() { employee, employee, employee, employee, employee, employee, employee, employee, employee };

            var detailsVM = new DetailsVM() { Employees = employees, Company = company, History = allHistory, Notes = notes };

            return View(detailsVM);
        }
    }
}
