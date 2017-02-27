namespace babi.Controllers
{
    using babi.Constants;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ControllerBase
    {
        [HttpGet("", Name = HomeControllerRoute.GetIndex)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return this.RedirectPermanent("/swagger");
        }
    }
}
