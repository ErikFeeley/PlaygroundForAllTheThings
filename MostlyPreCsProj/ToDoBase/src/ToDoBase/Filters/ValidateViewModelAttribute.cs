using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ToDoBase.Filters
{
    public class ValidateViewModelAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ValidateViewModelAttribute> _logger;

        public ValidateViewModelAttribute(ILogger<ValidateViewModelAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                _logger.LogError("There by View Model errors here", context.ModelState);
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
