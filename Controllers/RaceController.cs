using Microsoft.AspNetCore.Mvc;

namespace Social_Media.Controllers
{
    public class RaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
