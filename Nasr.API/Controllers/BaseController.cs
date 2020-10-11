using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Nasr.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

        protected ActionResult<T> Single<T>(T data)
        {
            return Ok(data);
        }

        protected ActionResult<List<T>> Collection<T>(List<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        protected ActionResult ErrorResponse(object obj)
        {
            return BadRequest(obj);
        }
    }
}
