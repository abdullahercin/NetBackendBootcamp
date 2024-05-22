using System.Net;
using Bootcamp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResult<T>(ResponseModelDto<T> response, string methodName,
            object routeValues)
        {
            return response.StatusCodes == HttpStatusCode.Created ? CreatedAtAction(methodName, routeValues, response) : new ObjectResult(response) { StatusCode = (int)response.StatusCodes };
            
        }


        public IActionResult CreateActionResult<T>(ResponseModelDto<T> response)
        {
            return response.StatusCodes == HttpStatusCode.NoContent ? new ObjectResult(null) { StatusCode = 204 } : new ObjectResult(response) { StatusCode = (int)response.StatusCodes };
        }

    }
}
