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
    public class CustomerRepository : ICustomer
    {
        readonly ApplicationDbContext _context;
        readonly CustomerMapper _mapper;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
            _mapper = new CustomerMapper();
        }

        public List<CustomerVM> GetAllCustomers()
        { 

            var customers = _context.Customers.Include(c => c.Orders).ToList();
            var cutomerVMs = _mapper.EmployessMappingFromModelToVM(customers);
            return cutomerVMs;

        }

        public CustomerVM GetCustomerById(int id)
        {
            var customer = _context.Customers.Include(c => c.Orders).Where(c => c.Id == id).FirstOrDefault();
            var customeVM = _mapper.OneEmployeeMappingFromModelToVM(customer);
            return customeVM;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateEmployee(CustomerVM customerVM)
        {
            var customer = _mapper.OneEmployeeMappingFromVmToModel(customerVM);
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Customer customer)
        {
            if (_context is null)
                return;


            _context.Remove(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomerByIdVM(int id)
        {
            var customer = _context.Customers.Include(c => c.Orders).Where(c => c.Id == id).FirstOrDefault();
            return customer;
        }
    }
}
