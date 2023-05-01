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
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
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
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Image,AddressId,GroupCategory,AppUserId")] Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }
            _groupRepository.Add(group);
            return RedirectToAction("Index");
        }




    }
}
