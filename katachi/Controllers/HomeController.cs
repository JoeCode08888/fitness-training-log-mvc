using Microsoft.AspNetCore.Mvc;

namespace katachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "TrainingLog");
        }
    }
}
