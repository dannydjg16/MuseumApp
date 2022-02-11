using System;
using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class Like
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }

        public virtual Artwork Art { get; set; }
        public virtual User User { get; set; }
    }
}
