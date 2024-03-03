using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models.Repositories;

namespace WebApi.Filters
{
    public class Validate_ShirtIdFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result=new BadRequestObjectResult(problemDetails);
                }
                else if (!ShirtRepository.ShirtExist(shirtId.Value)) {
                    context.ModelState.AddModelError("ShirtId", "Shirt does not exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result=new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
