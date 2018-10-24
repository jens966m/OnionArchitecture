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
        public ActionResult<IEnumerable<Order>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_orderService.GetFilteredOrder(filter));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

            //return Ok(_orderService.GetAllOrders());
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return _orderService.GetOrderById(id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST api/Orders
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                return _orderService.CreateOrder(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }




        }

        // PUT api/Orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            try
            {
                return _orderService.UpdateOrder(order);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            try
            {
                return _orderService.DeleteOrder(id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}