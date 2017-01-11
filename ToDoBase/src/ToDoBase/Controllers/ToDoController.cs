using Microsoft.AspNetCore.Mvc;

namespace ToDoBase.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
