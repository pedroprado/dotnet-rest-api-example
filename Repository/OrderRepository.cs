using System.Collections.Generic;
using System.Linq;
using web_api_example.Models;

namespace web_api_example.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public OrderRepository(RepositoryContext repositoryContext){
            this._repositoryContext = repositoryContext;
        }
        public void createOrder(Order order)
        {
            _repositoryContext.orders.Add(order);
            _repositoryContext.SaveChanges();
        }

        public void deleteOrderById(int order_id)
        {
            var order = _repositoryContext.orders.FirstOrDefault(o => o.orderId == order_id);
            _repositoryContext.Remove(order);
            _repositoryContext.SaveChanges();
        }

        public Order getOrderById(int order_id)
        {
            return _repositoryContext.orders.FirstOrDefault(order => order.orderId == order_id);
        }

        public IEnumerable<Order> getOrders()
        {
            return _repositoryContext.orders.ToList();
        }

        public void updateOrder(Order order)
        {
            _repositoryContext.orders.Update(order);
            _repositoryContext.SaveChanges();
        }
    }
}