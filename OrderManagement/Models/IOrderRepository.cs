using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        IEnumerable<Order> GetAllOrders();
        Order Add(Order order);
        Order Update(Order orderChanges);
        Order Delete(int id);
    }
}
