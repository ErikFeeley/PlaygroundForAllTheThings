using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoGaveUpProbablyCQRS.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // how to send back to previous view with required model data.
            }
        }
    }
}
