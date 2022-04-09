﻿using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class Artist
    {
        public Artist()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string BornLocation { get; set; }
        public string Bio { get; set; }
        public string PictureUrl { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
