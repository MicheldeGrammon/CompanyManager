using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Controllers
{


    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepo;
        private readonly ICompanyRepository _companyRepo;

        public NoteController(INoteRepository noteRepo, ICompanyRepository companyRepo)
        {
            _noteRepo = noteRepo;
            _companyRepo = companyRepo;
        }

        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(int id, Note obj)
        {
            try
            {
                var company = await _companyRepo.FindAsync(id);

                obj.Company = company;
                obj.CompanyId = company.Id;
                obj.Id = 0;
                await _noteRepo.Add(obj);

                return RedirectToAction("Details", "Companies", new { id = obj.CompanyId });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var companyId = (await _noteRepo.FindAsync(id)).CompanyId;
                await _noteRepo.RemoveAsync(id);

                return RedirectToAction("Details", "Companies", new { id = companyId });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
}
