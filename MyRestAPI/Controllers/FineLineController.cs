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
    public class FineLineController : ControllerBase
    {
        private readonly IFineLineService _fineLineService;

        public FineLineController(IFineLineService fineLineService)
        {
            _fineLineService = fineLineService;
        }
        // GET api/Fines
        [HttpGet]
        public IEnumerable<FineLine> Get()
        {
            return _fineLineService.GetFineLines();
        }

        // GET api/Fines/5
        [HttpGet("{id}")]
        public ActionResult<FineLine> Get(int id)
        {

            return _fineLineService.FindFineLineByIdIncludeFineType(id);
        }

        [HttpPost]
        public ActionResult<FineLine> Post([FromBody] FineLine fineLine)
        {
            try
            {
                return _fineLineService.CreateFineLine(fineLine);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<FineLine> Put(int id, [FromBody] FineLine fineLine)
        {
            if (id < 0 || id != fineLine.Id)
            {
                return BadRequest("parameter id and Fine id must be a match");
            }

            return _fineLineService.UpdateFineLine(fineLine);

        }

        [HttpDelete("{id}")]
        public ActionResult<FineLine> Delete(int id)
        {// delete virker ikke efter hensigten

            var fine = _fineLineService.DeleteFineLine(id);
            if (fine == null)
            {
                return StatusCode(404, "Did not found fine with id: " + id);
            }
            return Ok($"Fine with Id: {id} is Deleted");
        }


    }
}