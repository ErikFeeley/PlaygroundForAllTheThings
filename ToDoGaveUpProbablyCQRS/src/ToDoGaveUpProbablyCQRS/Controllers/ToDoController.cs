using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoGaveUpProbablyCQRS.Features.ToDoThings;
using ToDoGaveUpProbablyCQRS.Models;
using ToDoGaveUpProbablyCQRS.ViewModels;

namespace ToDoGaveUpProbablyCQRS.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        private readonly ILogger<ToDoController> _logger;
        private const int SOME_CONST_LOGEVENT_ID = 1000;

        public ToDoController(UserManager<ApplicationUser> userManager, IMediator mediator, ILogger<ToDoController> logger)
        {
            _userManager = userManager;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var result = await _mediator.Send(new ToDoThingsByUserIdQueryAsync(user.Id));

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ToDoThingViewModel toDoThingViewModel)
        {
            var user = await GetCurrentUserAsync();
            // holding on to createdId for now because we could use it to pass along to a details view.
            var createdId = await _mediator.Send(new AddToDoThingByUserIdCommandAsync(user.Id, toDoThingViewModel));
            _logger.LogInformation(SOME_CONST_LOGEVENT_ID, "Added a new ToDoThing", createdId);

            return RedirectToAction("Index");
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
