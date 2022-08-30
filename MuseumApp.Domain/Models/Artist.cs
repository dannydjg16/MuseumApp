using System.Collections.Generic;
using System.Linq;

namespace MuseumApp.Domain.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public int? Born { get; set; }
        public int? Died { get; set; }
        public int? ArtistAdderId { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }
        public User ArtistAdder { get; set; }


        public Artwork GetArtworkByID(int id)
        {
            return Artworks.FirstOrDefault(aw => aw.Id == id);
        }

        public bool VerifyArtistBirthYear()
        {
            if (Born > 2023)
            {
                return false;
            }
            else if (Born < -60000)
            {
                 return false;
            }
            return true;
        }
    }
}
