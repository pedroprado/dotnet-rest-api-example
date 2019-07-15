using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using web_api_example.Contracts;
using web_api_example.Models;
using web_api_example.Repository;

namespace web_api_example.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:Controller
    {

        private JObject createJsonResponse(Exception exception){
            JObject errorResponse = new JObject();
            errorResponse["error"] = exception.Message;
            errorResponse["stack"] = exception.StackTrace;
            if(exception.InnerException != null){
              errorResponse["message"] =   exception.InnerException.Message;
            }
            return errorResponse;
        }
        private readonly IOrderRepository _orderRepository;
        private readonly ILoggerManager _logger;

        public OrderController(IOrderRepository orderRepository,
                                ILoggerManager logger){
            this._orderRepository = orderRepository;
            this._logger = logger;
        }

        [HttpGet("{order_id}")]
        public IActionResult getOrderById(int order_id){
            var order = _orderRepository.getOrderById(order_id);
            return new ObjectResult(order);
        }

        [HttpGet("get/all")]
        public IActionResult getOrders(){
            IEnumerable<Order> orders = _orderRepository.getOrders();
            return new ObjectResult(orders);
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        public IActionResult createOrder([FromBody] Order order){
            try{
                _orderRepository.createOrder(order);
                return new ObjectResult(JsonConvert.DeserializeObject(@"{'message': 'Saved.'}"));
            }catch(Exception ex){
                return new ObjectResult(createJsonResponse(ex));
            }
        }

        [HttpPut("update")]
        [Consumes("application/json")]
        public IActionResult updateOrder([FromBody] Order order){
            try{
                 _orderRepository.updateOrder(order);
                return new ObjectResult(JsonConvert.DeserializeObject(@"{'message': 'Updated.'}"));
            }catch(Exception ex){
                return new ObjectResult(createJsonResponse(ex));
            }
        }

        [HttpDelete("delete/{order_id}")]
        public IActionResult deleteOrderById(int order_id){
            try{
                _orderRepository.deleteOrderById(order_id);
                return new ObjectResult(JsonConvert.DeserializeObject(@"{'message': 'Deleted.'}"));
            }catch(Exception ex){
                return new ObjectResult(createJsonResponse(ex));
            }
        }

        [HttpGet("join/customer")]
        public IActionResult getOrderWithCustomer(){
            
            var joinQuery = _orderRepository.getOrderWithCustomer();                    
            return new ObjectResult(joinQuery);

        }

        [HttpGet("get/one/{order_id}/{first_name}")]
        public IActionResult getOrderStatusByCustomerName(int order_id, string first_name){
            
            var result = _orderRepository.getOrderStatusByCustomerName(order_id, first_name);

            return new ObjectResult(JsonConvert.DeserializeObject(result));
        }

    }
}