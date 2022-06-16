using System.Linq;

namespace MuseumApp.DB.Mappers
{
    public static class UserMapper
    {
        public static Domain.Models.User Map(User entity)
        {
            return new Domain.Models.User
            {
                ID = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                FromLocation = entity.FromLocation,
                ProfilePicURL = entity.ProfilePicUrl,
                Likes = entity.Likes.Select(LikeMapper.Map)
            };
        }

        public static User Map(Domain.Models.User model)
        {
            return new User
            {
                Id = model.ID,
                Name = model.Name,
                Email = model.Email,
                FromLocation = model.FromLocation,
                ProfilePicUrl = model.ProfilePicURL
            };
        }
    }
}
