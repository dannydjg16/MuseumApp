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
    }
}
