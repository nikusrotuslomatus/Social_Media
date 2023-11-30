using Social_Media.Models;

namespace Social_Media.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAll();
        Task<Group> GetByIdAsync(int id);
        Task<IEnumerable<Group>> GetGroupByCity(string city);
        Task<IEnumerable<Group>> GetGroupByGroupCategory(string GroupCategory);
        bool Add(Group group);
        bool Update(Group group);
        bool Delete(Group group);
        bool Save();
        

    }
}
