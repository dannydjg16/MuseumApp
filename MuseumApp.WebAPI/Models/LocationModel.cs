using System.Collections.Generic;

namespace MuseumApp.WebAPI.Models
{
    public class LocationModel
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

        public virtual LocationTypeModel Type { get; set; }
        public virtual IEnumerable<ArtworkModel> Artworks { get; set; }
    }
}
