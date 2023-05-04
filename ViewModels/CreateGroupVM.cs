using Social_Media.Data.Enum;
using Social_Media.Models;

namespace Social_Media.ViewModels
{
    public class CreateGroupVM
    {
        
        
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Address Address { get; set; }
        public string AppUserId { get; set; }
        public IFormFile Image { get; set; }
        public GroupCategory GroupCategory { get; set; }
    }
}
