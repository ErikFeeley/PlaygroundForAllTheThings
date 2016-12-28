using System.Linq;
using CoreCQRSApp.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreCQRSApp.Controllers
{
    public class HomeController : Controller
    {
        // just for testing
        private readonly ToDoContext _toDoContext;

        public HomeController(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var results = _toDoContext.Users.ToList();

            return View();
        }
    }
}
