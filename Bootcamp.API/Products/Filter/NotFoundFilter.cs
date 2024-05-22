using Bootcamp.Service;
using Bootcamp.Service.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bootcamp.API.Products.Filter;

public class NotFoundFilter(IProductRepository productRepository) : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var productIdFromAction = context.ActionArguments.Values.First()!;

        if (!int.TryParse(productIdFromAction.ToString(), out var productId))
        {
            return;
        }

        var hasProduct = productRepository.HasExist(productId).Result;

        if (hasProduct) return;

        var errorMessage = $"{productId} Id numaralı ürün bulunamadı.";
        var responseModel = ResponseModelDto<NoContent>.Fail(errorMessage);
        context.Result = new NotFoundObjectResult(responseModel);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}