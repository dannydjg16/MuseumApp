using System.Collections.Generic;
using System.Linq;

namespace MuseumApp.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public string LocationUrl { get; set; }
        public int? TypeId { get; set; }
        public string Country { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }

        public virtual LocationType Type { get; set; }
        public virtual IEnumerable<Artwork> Artworks { get; set; }

        public int GetArtworkCount()
        {
            return Artworks.ToList().Count;
        }
    }
}
