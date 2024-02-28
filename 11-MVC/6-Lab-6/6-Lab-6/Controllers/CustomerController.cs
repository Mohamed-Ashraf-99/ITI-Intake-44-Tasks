using BLL.Feature.Interface;
using BLL.Mapping;
using BLL.ModelVM;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _6_Lab_6.Controllers
{
    public class CustomerController : Controller
    {
        ICustomer _customer;
        IOrder _order;
        CustomerMapper _mapper;
        public CustomerController(ICustomer customer, IOrder order)
        {
            _customer = customer;
            _order = order;
            _mapper = new CustomerMapper();
        }
        // GET: CustomerController
        public ActionResult DisplayAllCustomers()
        {
            var customers = _customer.GetAllCustomers();

            return View("DisplayAllCustomers", customers);
        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {

            var customer = _customer.GetCustomerById(id);
            return View("Details", customer);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            var customerVM = new CustomerVM()
            {
                OrdersList = _order.GetAllOrders(),
                 
            };
            return View("Create", customerVM);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerVM customerVM)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    email = customerVM.email,
                    Gender = customerVM.Gender,
                    Name = customerVM.Name,
                    Orders = customerVM.Orders,
                    phoneNum = customerVM.phoneNum
                };

                _customer.AddCustomer(customer);

                return RedirectToAction(nameof(DisplayAllCustomers));
            }


            return View();

        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
                return BadRequest();
            var customer = _customer.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            var customerVM = new CustomerVM()
            {
                Id = customer.Id,
                email = customer.email,
                Gender = customer.Gender,
                Name = customer.Name,
                phoneNum = customer.phoneNum,
                Orders = customer.Orders,
                OrdersList = _order.GetAllOrders()
            };

            return View("Edit", customerVM);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerVM customerVM)
        {
            if(ModelState.IsValid)
            {
                var customerVmNew = new CustomerVM()
                {
                    Id = customerVM.Id,
                    email = customerVM.email,
                    Gender = customerVM.Gender,
                    Name = customerVM.Name,
                    phoneNum = customerVM.phoneNum,
                    Orders = customerVM.Orders,
                    OrdersList = _order.GetAllOrders()
                };
                _customer.UpdateEmployee(customerVmNew);
                return RedirectToAction(nameof(DisplayAllCustomers));
            }
         
                return View();
            
        }

        public IActionResult Delete(int id)
        {
            var customer = _customer.GetCustomerByIdVM(id);


            if (customer is not null)
                _customer.DeleteEmployee(customer);
            return RedirectToAction(nameof(DisplayAllCustomers));
        }
    }
}
