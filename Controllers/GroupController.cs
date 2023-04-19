using Microsoft.AspNetCore.Mvc;

using Social_Media.Data;
using Social_Media.Models;


namespace Social_Media.Controllers
{
    public class GroupController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Group> groups=_context.Groups.ToList();
            return View(groups);

        public IActionResult Index()
        {
            return View();

        }
    }
}
