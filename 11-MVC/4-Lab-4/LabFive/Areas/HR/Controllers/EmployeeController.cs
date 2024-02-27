using BLL.Feature.Interface;
using BLL.Feature.Repository;
using BLL.ModelVM;
using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _5_Lab_5.Areas.HR.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployee Employee = new EmployeeRepo();
        //private readonly ApplicationDbContext _context = new ();

        // GET: EmployeeController
        public ActionResult ShowAllEmployees()
        {
            var employees = Employee.GetAllEmployees();
            return View("ShowAllEmployees", employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = Employee.GetEmployeeById(id);
            return View("Details", employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            var employeeVM = new EmployeeVM()
            {
                Departments = Employee.GetAllDepartments(),
            };
            return View("Create", employeeVM);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeVM employee)
        {
            try
            {

                var employeeEntity = new Employee()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    joinDate = employee.joinDate,
                    phoneNum = employee.phoneNum,
                    Salary = employee.Salary,
                    Password = employee.Password,
                    DepartmentId = employee.DeptId,
                    Department = employee.Department,

                };

                Employee.AddEmployee(employeeEntity);

                return RedirectToAction(nameof(ShowAllEmployees));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5

        public IActionResult Edit(int id)
        {
            if (id == null)
                return BadRequest();

            var employee = Employee.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            var employeeVM = new EmployeeVM()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                joinDate = employee.joinDate,
                Password = employee.Password,
                Salary = employee.Salary,
                phoneNum = employee.phoneNum,
                Department = employee.Department,
                DeptId = employee.DeptId,
                Departments = Employee.GetAllDepartments(),
            };

            return View("Edit", employeeVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeVM employeeVM)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = employeeVM.Id,
                    Name = employeeVM.Name,
                    Email = employeeVM.Email,
                    Department = employeeVM.Department,
                    DepartmentId = employeeVM.DeptId,
                    joinDate = employeeVM.joinDate,
                    Password = employeeVM.Password,
                    phoneNum = employeeVM.phoneNum,
                    Salary = employeeVM.Salary,

                };
                Employee.UpdateEmployee(employee);
                return RedirectToAction(nameof(ShowAllEmployees));
            }
            catch
            {
                return View(employeeVM);
            }

        }


       

        //// POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public IActionResult Delete(int id)
        {
            var employee = Employee.GetById(id);

           

            if (employee is not null)
                Employee.DeleteEmployee(employee);
            return RedirectToAction(nameof(ShowAllEmployees));
        }


    }
}
