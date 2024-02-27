using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public decimal Salary { get; set; }

        public DateTime joinDate { get; set; }
        public string Email { get; set; }
        public int phoneNum { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
