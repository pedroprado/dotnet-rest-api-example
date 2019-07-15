using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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

        public IEnumerable<Order> getOrderWithCustomer(){

            var joinQuery = from order in _repositoryContext.orders    
                            join customer in _repositoryContext.customers
                            on  order.customerId equals customer.customerId
                            select new Order(){
                                orderId = order.orderId,
                                customerId = order.customerId,
                                orderDate = order.orderDate,
                                status = order.status,
                                comments = order.comments,
                                shippedDate = order.shippedDate,
                                shipperId = order.shipperId,
                                Customer = customer
                            };

            return joinQuery;
        }

        public string getOrderStatusByCustomerName(int order_id, string first_name){
            
            var query = from order in _repositoryContext.orders
                        join customer in _repositoryContext.customers
                        on order.customerId equals customer.customerId
                        where order.orderId == order_id && customer.firstName == first_name
                        select new {
                            OrderId = order.orderId,
                            OrderDate = order.orderDate,
                            OrderStatus = order.status,
                            CustomerName = customer.firstName

                        };


            return JsonConvert.SerializeObject(query);
        }

    }
}