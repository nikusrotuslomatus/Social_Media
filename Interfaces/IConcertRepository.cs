using Social_Media.Models;

namespace Social_Media.Interfaces
{
    public interface IConcertRepository
    {
        Task<IEnumerable<Concert>> GetAll();
        Task<Concert> GetByIdAsync(int id);
        Task<IEnumerable<Concert>> GetConcertsByCity(string city);
        Task<IEnumerable<Concert>> GetConcertByConcertCategory(string ConcertCategory);
        bool Add(Concert concert);
        bool Update(Concert concert);
        bool Delete(Concert concert);
        bool Save();
    }  
}
