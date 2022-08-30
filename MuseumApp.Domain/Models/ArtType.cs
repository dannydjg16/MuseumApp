using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class ArtType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Artwork> Artworks { get; set; }
    }
}
