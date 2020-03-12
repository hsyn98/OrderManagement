using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public SqlOrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Order Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            Order order = context.Orders.Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.Orders;
        }

        public Order GetOrder(int id)
        {
            return context.Orders.Find(id);
        }

        public Order Update(Order orderChanges)
        {
            var order = context.Orders.Attach(orderChanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return orderChanges;
        }
    }
}
