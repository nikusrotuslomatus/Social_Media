using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;
using Social_Media.Repository;
using Social_Media.Services;
using Social_Media.ViewModels;

namespace Social_Media.Controllers
{
    public class ConcertsController : Controller
    {

        private readonly IConcertRepository _concertRepository;
        private readonly IPhotoService _photoService;
        public ConcertsController(IConcertRepository concertRepository, IPhotoService photoService)
        {
            _concertRepository = concertRepository;
            _photoService = photoService;   
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
        public async Task<IActionResult> Create(CreateConcertVM concertVM)
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
