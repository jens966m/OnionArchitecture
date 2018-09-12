using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MyRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {

            return _customerService.GetAllCustomers();
        }

        // GET api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            //return _customerService.FindCustomerById(id);

            return _customerService.FindCustomerByIdIncludeOrders(id);
        }

        // POST api/Customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer cust)
        {
            if (string.IsNullOrEmpty(cust.FirstName)||string.IsNullOrEmpty(cust.LastName)||string.IsNullOrEmpty(cust.Address))
            {
                return BadRequest("missing field");
            }
            
           return _customerService.CreateCustomer(cust);

        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer cust)
        {
            if (id<0||id !=cust.Id)
            {
                return BadRequest("parameter id and customer id must be a match");
            }

            return _customerService.UpdateCustomer(cust);

        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {

            var customer = _customerService.DeleteCustomer(id);
            if (customer ==null)
            {
                return StatusCode(404, "Did not found customer with id: " + id);
            }
            return Ok($"Customer with Id: {id} is Deleted");
        }
    }
}
