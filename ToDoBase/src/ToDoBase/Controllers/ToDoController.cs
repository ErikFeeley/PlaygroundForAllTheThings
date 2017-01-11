using System;
using Microsoft.AspNetCore.Mvc;
using ToDoBase.ViewModels;

namespace ToDoBase.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ToDoViewModel toDoViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
