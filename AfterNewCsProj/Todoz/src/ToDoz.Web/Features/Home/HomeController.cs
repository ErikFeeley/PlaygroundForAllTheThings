using Microsoft.AspNetCore.Mvc;

namespace ToDoz.Web.Features.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
