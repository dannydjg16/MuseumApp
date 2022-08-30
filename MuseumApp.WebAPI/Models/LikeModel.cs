namespace MuseumApp.WebAPI.Models
{
    public class LikeModel
    {
        public int UserId { get; set; }
        public int ArtId { get; set; }

        public ArtworkModel Art { get; set; }
        public UserModel User { get; set; }
    }
}
