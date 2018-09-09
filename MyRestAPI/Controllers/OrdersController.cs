using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {

            return _orderService.GetAllOrders();
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderById(id);
        }

        // POST api/Orders
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            return _orderService.CreateOrder(order);

        }

        // PUT api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            return _orderService.UpdateOrder(order);

        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {

            var order = _orderService.DeleteOrder(id);
            if (order == null)
            {
                return StatusCode(404, "Did not found order with id: " + id);
            }
            return Ok($"Order with Id: {id} is Deleted");
        }


    }
}