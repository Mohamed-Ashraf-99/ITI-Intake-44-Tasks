using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string email { get; set; }
        public int phoneNum { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
