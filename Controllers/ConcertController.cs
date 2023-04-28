using Microsoft.AspNetCore.Mvc;
using Social_Media.Data;
using Social_Media.Models;

namespace Social_Media.Controllers
{
    public class ConcertController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            List<Concert> concerts = _context.Concerts.ToList();
            return View(concerts);
        }
    }
}
