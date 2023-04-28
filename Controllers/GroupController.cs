using Microsoft.AspNetCore.Mvc;

using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;
using Social_Media.Repository;

namespace Social_Media.Controllers
{
    public class GroupController : Controller
    {

        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository _groupRepository)
        {
            this._groupRepository = _groupRepository;
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
    }
}