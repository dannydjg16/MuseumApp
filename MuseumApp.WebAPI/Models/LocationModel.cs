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

        public virtual LocationTypeModel Type { get; set; }
        public virtual IEnumerable<ArtworkModel> Artworks { get; set; }


    }
}
