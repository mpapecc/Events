using Microsoft.AspNetCore.Mvc;

namespace Events.Api.Controllers
{
    public class PingController : BaseApiController
    {
        [HttpGet]
        public ActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}
