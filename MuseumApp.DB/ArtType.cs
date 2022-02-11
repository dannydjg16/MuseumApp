using System;
using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class ArtType
    {
        public ArtType()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
