using System.Linq;

namespace MuseumApp.DB.Mappers
{
    public static class UserMapper
    {
        // Put in DB Model, Get back Domain Model
        public static Domain.Models.User Map(User entity)
        {
            return new Domain.Models.User
            {
                ID = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                FromLocation = entity.FromLocation,
                ProfilePicURL = entity.ProfilePicUrl,
                CurrentStateProvince = entity.CurrentStateProvince,
                CurrentCountry = entity.CurrentCountry,
                CurrentCity = entity.CurrentCity,
                Likes = entity.Likes.Select(LikeMapper.Map)
            };
        }

        // Put in Domain Model, Get back DB Model
        public static User Map(Domain.Models.User model)
        {
            return new User
            {
                Id = model.ID,
                Name = model.Name,
                Email = model.Email,
                FromLocation = model.FromLocation,
                ProfilePicUrl = model.ProfilePicURL,
                CurrentStateProvince = model.CurrentStateProvince,
                CurrentCountry = model.CurrentCountry,
                CurrentCity = model.CurrentCity
            };
        }
    }
}
