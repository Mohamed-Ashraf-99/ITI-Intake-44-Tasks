using BLL.ModelVM;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class CustomerMapper
    {
        public List<Customer> EmployessMappingFromVMToModel(List<CustomerVM> customersVMs)
        {
            var customers = new List<Customer>();

            foreach (CustomerVM customerVM in customersVMs)
            {
                var customer = OneEmployeeMappingFromVmToModel(customerVM);

                customers.Add(customer);
            }


            return customers;
        }


        public List<CustomerVM> EmployessMappingFromModelToVM(List<Customer> customers)
        {
            var customerVMs = new List<CustomerVM>();

            foreach (Customer customer in customers)
            {
                var customerVM = OneEmployeeMappingFromModelToVM(customer);

                customerVMs.Add(customerVM);
            }


            return customerVMs;
        }

        public Customer OneEmployeeMappingFromVmToModel(CustomerVM customerVM)
        {

            var customer = new Customer()
            {
                Id = customerVM.Id,
                Name = customerVM.Name,
                email = customerVM.email,
                Gender = customerVM.Gender,
                Orders = customerVM.Orders,
                phoneNum = customerVM.phoneNum
            };

            return customer;
        }

        public CustomerVM OneEmployeeMappingFromModelToVM(Customer customer)
        {

            var customerVM = new CustomerVM()
            {
                Id = customer.Id,
                Name = customer.Name,
                email = customer.email,
                Gender = customer.Gender,
                Orders = customer.Orders,
                phoneNum = customer.phoneNum
            };

            return customerVM;
        }
    }
}
