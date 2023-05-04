using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;

namespace Social_Media.Controllers
{
    public class ConcertsController : Controller
    {

        private readonly IConcertRepository _concertRepository;

        public ConcertsController(IConcertRepository concertRepository)
        {
            _concertRepository = concertRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Concert> concerts = await _concertRepository.GetAll();
            return View(concerts);


        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            Concert concert = await _concertRepository.GetByIdAsync(id);
            return View(concert);


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Concert concert)
        {
            if (ModelState.IsValid)
            {
                _concertRepository.Add(concert);
                return RedirectToAction("Index");
            }
            return View(concert);

        }




    }
}
