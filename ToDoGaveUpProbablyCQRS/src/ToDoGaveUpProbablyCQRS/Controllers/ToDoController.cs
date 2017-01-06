using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public ToDoController(UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var result = await _mediator.Send(new ToDoThingsByUserIdQueryAsync { UserId = user.Id }) ?? new List<ToDoThing>();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // [SomeModelStateValidationAttribute?]
        public async Task<IActionResult> Add(ToDoThingViewModel toDoThingViewModel)
        {
            // this sucks needs rework.
            if (!ModelState.IsValid) return View(toDoThingViewModel);

            var user = await GetCurrentUserAsync();
            // holding on to createdId for now because we could use it to pass along to a details view.
            // what about getting some kind of result back though to check if the operation succeeds or not.
            // so some kind of response object...?... hmm...
            var createdId = await _mediator.Send(new AddToDoThingByUserIdCommandAsync(user.Id, toDoThingViewModel));

            return RedirectToAction("Index");
        }

        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}
