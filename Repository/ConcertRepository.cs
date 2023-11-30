using Microsoft.EntityFrameworkCore;
using Social_Media.Data;
using Social_Media.Interfaces;
using Social_Media.Models;

namespace Social_Media.Repository
{
    public class ConcertRepository : IConcertRepository
        
    {
        private readonly ApplicationDbContext _context;

        public ConcertRepository(ApplicationDbContext context) {
            this._context = context;
            
        }
        public bool Add(Concert concert)
        {
            this._context.Add(concert);
            return Save();
        }

        public bool Delete(Concert concert)
        {
            this._context.Remove(concert);
            return Save();
        }

        public async Task<IEnumerable<Concert>> GetAll()
        {
            return await _context.Concerts.ToListAsync();

        }

        public async Task<Concert> GetByIdAsync(int id)
        {
            return await _context.Concerts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Concert>> GetConcertsByCity(string city)
        {
            return await _context.Concerts.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<IEnumerable<Concert>> GetConcertByConcertCategory(string ConcertCategory)
        {
            return await _context.Concerts.Where(c => c.ConcertCategory.ToString() == ConcertCategory).ToListAsync();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Concert concert)
        {
            _context.Update(concert);
            return Save();
        }
    }
}
