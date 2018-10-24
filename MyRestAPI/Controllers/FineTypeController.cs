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
    public class FineTypeController : ControllerBase
    {
        private readonly IFineTypeService _fineTypeService;

        public FineTypeController(IFineTypeService fineTypeService)
        {
            _fineTypeService = fineTypeService;
        }
        // GET api/fineTypes
        [HttpGet]
        public ActionResult<IEnumerable<FineType>> Get()
        {

            return _fineTypeService.GetAllFineTypes();
        }

        // GET api/FineTypes/5
        [HttpGet("{id}")]
        public ActionResult<FineType> Get(int id)
        {
            return _fineTypeService.FindFineTypeById(id);
        }

        // POST api/Customers
        [HttpPost]
        public ActionResult<FineType> Post([FromBody] FineType fineType)
        {
            try
            {
                return _fineTypeService.CreateFineType(fineType);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public ActionResult<FineType> Put(int id, [FromBody] FineType fineType)
        {
            if (id < 0 || id != fineType.Id)
            {
                return BadRequest("parameter id and fineType id must be a match");
            }

            return _fineTypeService.UpdatFineType(fineType);

        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<FineType> Delete(int id)
        {// delete virker ikke efter hensigten

            var fineType = _fineTypeService.DeleteFineType(id);
            if (fineType == null)
            {
                return StatusCode(404, "Did not found fineType with id: " + id);
            }
            return Ok($"fineType with Id: {id} is Deleted");
        }
    }
}
