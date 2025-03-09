using Microsoft.AspNetCore.Mvc;

namespace Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}
