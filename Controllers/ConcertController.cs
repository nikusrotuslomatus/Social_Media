using Microsoft.AspNetCore.Mvc;
using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;

namespace Social_Media.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcertRepository _concertRepository;

        public ConcertController(IConcertRepository concertRepository)
        {
            this._concertRepository = concertRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Concert> Concerts = await _concertRepository.GetAll();
            return View(Concerts);


        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            Concert Concert = await _concertRepository.GetByIdAsync(id);
            return View(Concert);


        }
    }
}
