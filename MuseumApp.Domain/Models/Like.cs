namespace MuseumApp.Domain.Models
{
    public class Like
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }

        public Artwork Art { get; set; }
        public User User { get; set; }
    }
}
