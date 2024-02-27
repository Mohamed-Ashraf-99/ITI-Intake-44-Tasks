using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelVM
{
    public class EmployeeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Department Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password Description must be between 6 and 100 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime joinDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public int phoneNum { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        public int DeptId { get; set; }

        public IEnumerable<Department>? Departments { get; set; }
        public virtual Department Department { get; set; }
    }
}
