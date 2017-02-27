using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoThing.Features.Task
{
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
