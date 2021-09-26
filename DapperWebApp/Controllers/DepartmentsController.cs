using DapperAssignment.Dto;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepo;

        public DepartmentsController(IDepartmentRepository departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var departments = await _departmentRepo.GetAll();
                return View(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            return await _getDepartmentModelById(id, "Create", "View");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentForCreationDto departmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departmentRepo.CreateDepartment(departmentModel);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            return await _getDepartmentModelById(id, "Create", "Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DepartmentForUpdateDto departmentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departmentRepo.UpdateDepartment(id, departmentModel);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbDepartmentModel = await _departmentRepo.GetById(id);
                if (dbDepartmentModel == null)
                    return NotFound();
                await _departmentRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private async Task<IActionResult> _getDepartmentModelById(int id, string renderView, string viewType)
        {
            try
            {
                var departmentModel = await _departmentRepo.GetById(id);
                departmentModel.ViewType = viewType;
                return View(renderView, departmentModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}