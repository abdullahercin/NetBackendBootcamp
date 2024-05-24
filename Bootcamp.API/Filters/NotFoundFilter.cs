using Bootcamp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace Bootcamp.API.Filters;

public class NotFoundFilter<T>(IGenericRepository<T> repository) : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var idFromAction = context.ActionArguments.Values.First()!;

        if (!int.TryParse(idFromAction.ToString(), out var id))
        {
            return;
        }

        var hasEntity = repository.HasExist(id).Result;

        if (hasEntity) return;

        var errorMessage = $"{id} Id numaralý {typeof(T).Name} bulunamadý.";
        Log.Error(errorMessage);
        var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
        context.Result = new NotFoundObjectResult(responseModel);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}