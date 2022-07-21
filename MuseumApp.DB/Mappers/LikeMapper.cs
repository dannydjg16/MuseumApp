namespace MuseumApp.DB.Mappers
{
    public static class LikeMapper
    {
        // Put in Domain Model, Get back DB Model
        public static Like Map(Domain.Models.Like like)
        {
            return new Like
            {
                ArtId = like.ArtId,
                UserId = like.UserId
            };
        }

        // Put in DB Model, Get back Domain Model
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
