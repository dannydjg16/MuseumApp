using System.Collections.Generic;

#nullable disable

namespace MuseumApp.DB
{
    public partial class Artwork
    {
        public Artwork()
        {
            LikesNavigation = new HashSet<Like>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public int? YearCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Likes { get; set; }
        public int ArtistId { get; set; }
        public int? MediumId { get; set; }
        public int? LocationNow { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Location LocationNowNavigation { get; set; }
        public virtual ArtType Medium { get; set; }
        public virtual ICollection<Like> LikesNavigation { get; set; }
    }
}
