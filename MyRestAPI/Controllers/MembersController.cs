using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MyRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        
        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        // GET api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {

            return _memberService.GetAllMembers();
        }

        // GET api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Member> Get(int id)
        {
            //try
            //{
            //return _customerService.FindCustomerById(id);
            //}
            //catch (Exception e)
            //{

            //    throw BadRequest(e.Message);
            //}


            //return _customerService.FindCustomerByIdIncludeOrders(id);
            return _memberService.FindMemberByIdIncludeFines(id);
        }

        // POST api/Customers
        [HttpPost]
        public ActionResult<Member> Post([FromBody] Member memb)
        {
            try
            {
                return _memberService.CreateMember(memb);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public ActionResult<Member> Put(int id, [FromBody] Member cust)
        {
            if (id<0||id !=cust.Id)
            {
                return BadRequest("parameter id and customer id must be a match");
            }

            return _memberService.UpdateMember(cust);

        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Member> Delete(int id)
        {// delete virker ikke efter hensigten

            var customer = _memberService.DeleteMember(id);
            if (customer ==null)
            {
                return StatusCode(404, "Did not found customer with id: " + id);
            }
            return Ok($"Customer with Id: {id} is Deleted");
        }
    }
}
