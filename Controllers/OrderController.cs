using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web_api_example.Models;
using web_api_example.Repository;

namespace web_api_example.Controllers
{
    [Route("api/[controller]")]
    public class OrderController:Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository){
            this._orderRepository = orderRepository;
        }

        [HttpGet("{order_id}")]
        public IActionResult getOrderById(int order_id){
            var orderFound = _orderRepository.getOrderById(order_id);
          
           return new ObjectResult(orderFound);
        }

      



    }
}