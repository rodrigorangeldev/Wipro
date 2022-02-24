using Microsoft.AspNetCore.Mvc;
using QueueProcess_API.Data;

namespace QueueProcess_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetItemFilaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFila()
        {
            var Queue = CurrencyQueue.Queue;

            if(Queue.Count == 0)
            {
                return NotFound();
            }

            var item = Queue.Dequeue();

            return Ok(new { item });
        }
    }
}
