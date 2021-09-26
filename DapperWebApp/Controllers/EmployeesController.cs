using DapperAssignment.Dto;
using EfAssignmentDapper.Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace DapperWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _deptRepo;

        public EmployeesController(IEmployeeRepository employeeRepo, IDepartmentRepository deptRepo)
        {
            _deptRepo = deptRepo;
            _employeeRepo = employeeRepo;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var employees = await _employeeRepo.GetAll();
                foreach (Employee emp in employees)
                {
                    emp.Department = await _deptRepo.GetById(emp.DeptId);
                }
                return View(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            return await _getEmployeeModelById(id, "EmployeeView", "View");
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Departments = await _deptRepo.GetAll();
                return View("EmployeeView");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeForCreationDto employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeRepo.CreateEmployee(employeeModel);
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
            try
            {
                ViewBag.Departments = await _deptRepo.GetAll();
                return await _getEmployeeModelById(id, "EmployeeView", "Edit");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeForUpdateDto employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeRepo.UpdateEmployee(id, employeeModel);
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
                var dbEmployeeModel = await _employeeRepo.GetById(id);
                if (dbEmployeeModel == null)
                    return NotFound();

                await _employeeRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private async Task<IActionResult> _getEmployeeModelById(int id, string renderView, string viewType)
        {
            try
            {
                var employeeModel = await _employeeRepo.GetById(id);
                employeeModel.Department = await _deptRepo.GetById(employeeModel.DeptId);
                employeeModel.ViewType = viewType;
                return View(renderView, employeeModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
