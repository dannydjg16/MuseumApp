using System;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class LikeModelMapper
    {
        public static LikeModel Map(Domain.Models.Like like)
        {
            return new LikeModel
            {
                ArtId = like.ArtId,
                UserId = like.UserId
            };
        }

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
