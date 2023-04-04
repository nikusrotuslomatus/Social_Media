using Microsoft.AspNetCore.Mvc;

namespace Social_Media.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
