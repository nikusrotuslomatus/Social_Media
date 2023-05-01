using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Social_Media.Models
{
    public class AppUser: IdentityUser
    {
        
        public int? Chords { get; set; }
        public int? Songs { get; set; }
        public Address? Address { get; set; }
        public ICollection<Concert> Concerts { get; set; }
        public ICollection<Group> Groups { get; set; }




    }
}
