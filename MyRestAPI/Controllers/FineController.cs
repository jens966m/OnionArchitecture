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
    public class FinesController : ControllerBase
    {
        private readonly IFineService _fineService;

        public FinesController(IFineService fineService)
        {
            _fineService = fineService;
        }
        // GET api/Fines
        [HttpGet]
        public ActionResult<IEnumerable<Fine>> Get()
        {

            return _fineService.GetAllFines();
        }

        // GET api/Fines/5
        [HttpGet("{id}")]
        public ActionResult<Fine> Get(int id)
        {

            return _fineService.FindFineByIdIncludeFineType(id);
        }

        // POST api/Fines
        [HttpPost]
        public ActionResult<Fine> Post([FromBody] Fine fine)
        {
            try
            {
                return _fineService.CreateFine(fine);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // PUT api/Fines/5
        [HttpPut("{id}")]
        public ActionResult<Fine> Put(int id, [FromBody] Fine fine)
        {
            if (id < 0 || id != fine.Id)
            {
                return BadRequest("parameter id and Fine id must be a match");
            }

            return _fineService.UpdateFine(fine);

        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Fine> Delete(int id)
        {

            var fine = _fineService.DeleteFine(id);
            if (fine == null)
            {
                return StatusCode(404, "Did not found fine with id: " + id);
            }
            return Ok($"Fine with Id: {id} is Deleted");
        }
    }
}
