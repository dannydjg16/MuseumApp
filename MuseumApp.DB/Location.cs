using System;
using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class Location
    {
        public Location()
        {
            Artworks = new HashSet<Artwork>();
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string LocationUrl { get; set; }
        public int? TypeId { get; set; }

        public virtual LocationType Type { get; set; }
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
