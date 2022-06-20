using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class User
    {
        public User()
        {
            Likes = new HashSet<Like>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FromLocation { get; set; }
        public string ProfilePicUrl { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
