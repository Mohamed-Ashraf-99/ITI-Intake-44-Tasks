using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Feature.Interface
{
    public interface IOrder
    {
        List<Order> GetAllOrders();
    }
}
