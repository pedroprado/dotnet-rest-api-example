using System.Collections.Generic;
using web_api_example.Models;

namespace web_api_example.Repository
{
    public interface IOrderRepository
    {
         void createOrder(Order order);
         Order getOrderById(int order_id);
         IEnumerable<Order> getOrders();
         void updateOrder(Order order);
         void deleteOrderById(int order_id);
         
    }
}