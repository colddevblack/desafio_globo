using Microsoft.AspNetCore.Mvc;

namespace Front_Card_Sports.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
