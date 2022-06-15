namespace MuseumApp.DB.Mappers
{
    public static class LikeMapper
    {
        public static Like Map(Domain.Models.Like like)
        {
            return new Like
            {
                ArtId = like.ArtId,
                UserId = like.UserId
            };
        }

        public static Domain.Models.Like Map(Like entity)
        {
            return new Domain.Models.Like
            {
                ArtId = entity.ArtId,
                UserId = entity.UserId
            };
        }
    }
}
