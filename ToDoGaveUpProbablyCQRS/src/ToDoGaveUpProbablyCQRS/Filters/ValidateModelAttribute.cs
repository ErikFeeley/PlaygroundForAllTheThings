using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoGaveUpProbablyCQRS.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;

                context.Result = new ViewResult
                {
                    ViewData = controller.ViewData,
                    TempData = controller.TempData
                };
            }
        }
    }
}
