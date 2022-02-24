using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueueProcess_API.Data;
using QueueProcess_API.Models;

namespace QueueProcess_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddItemFilaController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddFila([FromBody]List<ParamValues> Param)
        {

            var Queue = CurrencyQueue.Queue;

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Error = "Verify your param" });
                
            }

            Param.ForEach(x => Queue.Enqueue(x));

            return Ok(new { Info = $"Add. Queue length: {Queue.Count}" });



        }
    }
}
