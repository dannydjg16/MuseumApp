using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string LocationUrl { get; set; }
        public int? TypeId { get; set; }

        public virtual LocationType Type { get; set; }
        public virtual IEnumerable<Artwork> Artworks { get; set; }
    }
}
