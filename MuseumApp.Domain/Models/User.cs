using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FromLocation { get; set; }
        public string ProfilePicURL { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
