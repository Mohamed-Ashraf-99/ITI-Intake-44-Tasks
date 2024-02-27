using BLL.ModelVM;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Feature.Interface
{
    public interface IEmployee
    {
        List<EmployeeVM> GetAllEmployees();

        EmployeeVM GetEmployeeById(int id);

        List<Department> GetAllDepartments();

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee GetById(int id);
    }
}
