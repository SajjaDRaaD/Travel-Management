using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public abstract class BaseController:Controller
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
            => result is null ? NotFound() : Ok(result);
    }
}
