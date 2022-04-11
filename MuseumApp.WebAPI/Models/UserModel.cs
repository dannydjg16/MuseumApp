using System;
namespace MuseumApp.WebAPI.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FromLocation { get; set; }
        public string ProfilePicURL { get; set; }
    }
}
