using Bootcamp.Service;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                var responseModel = ResponseModelDto<NoContent>.Fail(errors);
                context.Result = new BadRequestObjectResult(responseModel);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
