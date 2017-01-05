using System;
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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _mediator.SendAsync(new ToDoThingsByUserIdQueryAsync { UserId = user.Id });

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
            if (!ModelState.IsValid) return View(toDoThingViewModel);

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _mediator.SendAsync(new AddToDoThingByUserIdCommandAsync { UserId = user.Id, ToDoThingViewModel = toDoThingViewModel });

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return View(toDoThingViewModel);
        }
    }
}
