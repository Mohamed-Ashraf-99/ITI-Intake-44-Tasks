using BLL.Feature.Interface;
using BLL.Mapping;
using BLL.ModelVM;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Feature.Repository
{
    public class EmployeeRepo : IEmployee
    {
        EmployeeMap _employeeMap = new EmployeeMap(); 

        ApplicationDbContext _context = new ApplicationDbContext();
        public EmployeeRepo()
        {
            
        }

        public EmployeeRepo(ApplicationDbContext context, EmployeeMap employeeMap)
        {
            _context = context;
            _employeeMap = employeeMap;
        }
        public List<EmployeeVM> GetAllEmployees()
        {

            var employees = _context.Employees.Include(c => c.Department).ToList();
            var employeeVMs = _employeeMap.EmployessMapping(employees);
            return employeeVMs;
        }

        public EmployeeVM GetEmployeeById(int id)
        {

            var employee = _context.Employees.Include(c => c.Department).Where(e => e.Id == id).FirstOrDefault();
            var employeeVM = _employeeMap.OneEmployeeMapping(employee);
            return employeeVM;
        }

        public Employee GetById(int id)
        {

            var employee = _context.Employees.Include(c => c.Department).Where(e => e.Id == id).FirstOrDefault();
            return employee;
        }

        public List<Department> GetAllDepartments()
        {
            var departments = _context.Departments.ToList();

            return departments;
        }

        public void AddEmployee(Employee employee)
        {
            //_context.Departments.Add(department);

            _context.Employees.Add(employee);

            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            if (_context is null)
                return;

            _context.Remove(employee);
            _context.SaveChanges();
        }

    }
}
