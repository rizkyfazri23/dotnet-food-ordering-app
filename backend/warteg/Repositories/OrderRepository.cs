using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using warteg.Models;
using warteg.Data;

namespace warteg.Repositories
{
    public class OrderRepository
    {
        private readonly WartegDbContext _dbContext;

        public OrderRepository(WartegDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == orderId);
        }
    }
}
