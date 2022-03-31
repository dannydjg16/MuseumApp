using System;
using System.Collections.Generic;

namespace MuseumApp.WebAPI.Models
{
    public class ArtistModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        //public IEnumerable<ArtworkModel> Artworks { get; set; }
    }
}
