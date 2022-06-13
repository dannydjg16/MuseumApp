using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public int? Born { get; set; }
        public int? Died { get; set; }
        public int? ArtistAdderId { get; set; }
        //public IEnumerable<Artwork> Artworks { get; set; }
    }
}
