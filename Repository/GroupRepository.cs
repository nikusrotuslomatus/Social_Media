using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;

namespace Social_Media.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        

        public bool Add(Group group)
        {
            _context.Add(group);
            return Save();
        }

        public bool Delete(Group group)
        {
            _context.Remove(group);
            return Save();
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();

        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(i => i.Id == id);
        }

        public  async Task<IEnumerable<Group>> GetGroupByCity(string city)
        {
            return await _context.Groups.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupByGroupCategory(string GroupCategory)
        {
            return await _context.Groups.Where(c => c.GroupCategory.ToString() == GroupCategory).ToListAsync();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Group group)
        {
            _context.Update(group); 
            return Save();
        }
    }
}
