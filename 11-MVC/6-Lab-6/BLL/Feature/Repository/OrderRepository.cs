using BLL.Feature.Interface;
using BLL.Mapping;
using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Feature.Repository
{
    public class OrderRepository : IOrder
    {
        readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            var orders = _context.Orders.ToList();

            return orders;
        }
    }
}
