using Events.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
