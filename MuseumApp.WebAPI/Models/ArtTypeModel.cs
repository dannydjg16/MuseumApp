using System.Collections.Generic;

namespace MuseumApp.WebAPI.Models
{
    public class ArtTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ArtworkModel> Artworks { get; set; }
    }
}
