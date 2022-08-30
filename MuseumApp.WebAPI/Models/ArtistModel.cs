using System.Collections.Generic;

namespace MuseumApp.WebAPI.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public int? Born { get; set; }
        public int? Died { get; set; }
        public int? ArtistAdderId { get; set; }
        public int ArtworkCount { get; set; }

        public IEnumerable<ArtworkModel> Artworks { get; set; }
    }
}
