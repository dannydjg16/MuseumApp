using System;

namespace MuseumApp.Domain.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? YearCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Likes { get; set; }
        public int ArtistId { get; set; }
        public int? MediumId { get; set; }
        public int? LocationNow { get; set; }
        public int? ArtWorkAdderId { get; set; }
        public DateTime? DateAdded { get; set; }

        public Artist Artist { get; set; }
        public Location Location { get; set; }
        public ArtType Medium { get; set; }

        public bool VerifyArtCreatedYear()
        {
            if (YearCreated > 2023)
            {
                return false;
            }
            else if (YearCreated < -60000)
            {
                return false;
            }
            return true;
        }
    }
}
