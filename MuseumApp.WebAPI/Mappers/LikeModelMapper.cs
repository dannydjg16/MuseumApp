using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class LikeModelMapper
    {
        // Put in Domain Model, return API Model
        public static LikeModel Map(Domain.Models.Like like)
        {
            return new LikeModel
            {
                ArtId = like.ArtId,
                UserId = like.UserId
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Like Map(LikeModel model)
        {
            return new Domain.Models.Like
            {
                ArtId = model.ArtId,
                UserId = model.UserId
            };
        }
    }
}
