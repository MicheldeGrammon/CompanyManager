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
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;

        public CompaniesController(IEmployeeRepository employeeRepo, ICompanyRepository companyRepo)
        {
            _employeeRepo = employeeRepo;
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
        public IActionResult Create(Company obj)
        {
            _companyRepo.Add(obj);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _companyRepo.FindAsync(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _companyRepo.RemoveAsync(id);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var obj = await _companyRepo.FindAsync(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Company obj)
        {
            await _companyRepo.UpdateAsync(obj);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id, int employeeId)
        {
            var company = await _companyRepo.FindAsync(id);

            var allHistory = new List<History>() { };

            var note = new Note() { InvoiceNumber = "35703", Employee = "Harv Mudd" };
            var notes = new List<Note>() { note, note, note };


            var employees = await _employeeRepo.GetAllAsync(id);


            var employee = employees.FirstOrDefault(x=>x.Id==employeeId);

            var detailsVM = new DetailsVM() 
            { 
                Employees = employees,
                Company = company,
                History = allHistory,
                Notes = notes,
                Employee = employee
            };

            return View(detailsVM);
        }
    }
}
