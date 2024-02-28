using BLL.ModelVM;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Feature.Interface
{
    public interface ICustomer
    {
        List<CustomerVM> GetAllCustomers();
        CustomerVM GetCustomerById(int id);

        Customer GetCustomerByIdVM(int id);

        void AddCustomer(Customer customerVM);

        void UpdateEmployee(CustomerVM employeeVM);

        void DeleteEmployee(Customer customer);

    }
}
