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
using Social_Media.Repository;
using Social_Media.ViewModels;

namespace Social_Media.Controllers
{
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;
        private readonly IPhotoService _photoService;

        public GroupController(IGroupRepository groupRepository,IPhotoService photoService)
        {
            _groupRepository = groupRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Group> groups = await _groupRepository.GetAll();
            return View(groups);


        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            Group group = await _groupRepository.GetByIdAsync(id);
            return View(group);


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
           
            
            if (ModelState.IsValid)
            {
                
                _groupRepository.Add(group);
                return RedirectToAction("Index");
            }
            return View(group);

        }




    }
}

