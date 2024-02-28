using BLL.Enum;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace BLL.ModelVM
{
    public class CustomerVM : CustomerBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Customer Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customer Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Customer Phone Number is required")]
        public int phoneNum { get; set; }

        public List<Order>? OrdersList { get; set; }

        public virtual List<Order>? Orders { get; set; }


    }
}
