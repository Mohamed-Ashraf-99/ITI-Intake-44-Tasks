using BLL.ModelVM;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class EmployeeMap
    {
        public List<EmployeeVM> EmployessMapping(List<Employee> employees)
        {
            var employeeVMs = new List<EmployeeVM>();

            foreach (Employee employee in employees)
            {
                var employeeVM = new EmployeeVM()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    joinDate = employee.joinDate,
                    Password = employee.Password,
                    phoneNum = employee.phoneNum,
                    Salary = employee.Salary,
                    Department = employee.Department,
                };

                employeeVMs.Add(employeeVM);
            }


            return employeeVMs;
        }

        public EmployeeVM OneEmployeeMapping(Employee employee)
        {

            var employeeVM = new EmployeeVM()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                joinDate = employee.joinDate,
                Password = employee.Password,
                phoneNum = employee.phoneNum,
                Salary = employee.Salary,
                Department = employee.Department,
            };

            return employeeVM;
        }
    }
}
