﻿using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FromLocation { get; set; }
        public string ProfilePicURL { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentStateProvince { get; set; }
        public string CurrentCity { get; set; }

        public virtual IEnumerable<Like> Likes { get; set; }
    }
}
