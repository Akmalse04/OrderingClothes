using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models.Repositories;

namespace WebApi.Filters.ExceptionFilter
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strShirtId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strShirtId, out var shirtId))
            {
                if (!ShirtRepository.ShirtExist(shirtId))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt does not exist anymore");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}

