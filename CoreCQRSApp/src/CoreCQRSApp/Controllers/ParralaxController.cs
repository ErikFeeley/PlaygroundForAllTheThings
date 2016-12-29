using Microsoft.AspNetCore.Mvc;

namespace CoreCQRSApp.Controllers
{
    public class ParralaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
