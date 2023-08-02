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
        private readonly INoteRepository _noteRepo;
        private readonly IHistoryRepository _historyRepo;

        public CompaniesController(IEmployeeRepository employeeRepo,
                                   ICompanyRepository companyRepo,
                                   INoteRepository noteRepo,
                                   IHistoryRepository historyRepository)
        {
            _employeeRepo = employeeRepo;
            _companyRepo = companyRepo;
            _noteRepo = noteRepo;
            _historyRepo = historyRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies;

            try
            {
                companies = await _companyRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                return NotFound(new { Massage = "Companies not found", Error = ex.Message });
            }

            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new { Message = "Model invalid", Model = Json(obj) });
            }

            _companyRepo.Add(obj);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Company obj;

            try
            {
                obj = await _companyRepo.FindAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Massage = "Company not found", Error = ex.Message });
            }

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _companyRepo.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Massage = "Failed to delete company", Error = ex.Message });
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            Company obj;

            try
            {
                obj = await _companyRepo.FindAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Massage = "Company not found", Error = ex.Message });
            }

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Company obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Model invalid", Model = Json(obj) });
            }

            await _companyRepo.UpdateAsync(obj);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id, int employeeId)
        {
            try
            {
                var company = await _companyRepo.FindAsync(id);
                var allHistory = await _historyRepo.GetAllAsync(id);
                var notes = await _noteRepo.GetAllAsync(id);
                var employees = await _employeeRepo.GetAllAsync(id);
                var employee = employees.FirstOrDefault(x => x.Id == employeeId);

                var detailsVM = new DetailsVM(company, allHistory, notes, employees, employee);

                return View(detailsVM);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
}
