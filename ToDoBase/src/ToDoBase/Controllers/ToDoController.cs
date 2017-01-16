using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoBase.Data;
using ToDoBase.Models;
using ToDoBase.ViewModels;

namespace ToDoBase.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToDoController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var result = await _dbContext.ToDos.Where(td => td.ApplicationUserId == user.Id).ToListAsync() ?? new List<ToDo>();

            return View(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ToDoViewModel toDoViewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _dbContext.ToDos.AddAsync(new ToDo(user.Id, toDoViewModel.Title, toDoViewModel.Description));
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
