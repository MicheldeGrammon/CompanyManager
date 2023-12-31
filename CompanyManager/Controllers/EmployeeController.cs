﻿using CompanyManager.Data.Repository.IRepository;
using CompanyManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICompanyRepository _companyRepo;

        public EmployeeController(IEmployeeRepository employeeRepo, ICompanyRepository companyRepo)
        {
            _employeeRepo = employeeRepo;
            _companyRepo = companyRepo;
        }

        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(int id, Employee obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new { Message = "Model invalid", Model = Json(obj) });
            }

            try
            {
                var company = await _companyRepo.FindAsync(id);

                obj.Company = company;
                obj.CompanyId = company.Id;
                obj.Id = 0;
                await _employeeRepo.Add(obj);

                return RedirectToAction("Details", "Companies", new { id = obj.CompanyId });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            Employee obj;

            try
            {
                obj = await _employeeRepo.FindAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Massage = "Employee not found", Error = ex.Message });
            }

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var companyId = (await _employeeRepo.FindAsync(id)).CompanyId;
                await _employeeRepo.RemoveAsync(id);

                return RedirectToAction("Details", "Companies", new { id = companyId });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var obj = await _employeeRepo.FindAsync(id);
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Employee obj)
        {
            if (!ModelState.IsValid)
            {
                return NotFound(new { Message = "Model invalid", Model = Json(obj) });
            }

            try
            {
                var companyId = (await _employeeRepo.FindAsync(obj.Id)).CompanyId;
                await _employeeRepo.UpdateAsync(obj);

                return RedirectToAction("Details", "Companies", new { id = companyId });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
}
