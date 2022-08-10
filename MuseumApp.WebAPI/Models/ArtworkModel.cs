using System;

namespace MuseumApp.WebAPI.Models
{
    public class ArtworkModel
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

        public virtual ArtistModel Artist { get; set; }
        public virtual LocationModel Location { get; set; }
        public virtual ArtTypeModel Medium { get; set; }


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
