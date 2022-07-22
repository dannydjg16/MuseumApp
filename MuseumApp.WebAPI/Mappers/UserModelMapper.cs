using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class UserModelMapper
    {
        // Put in Domain Model, return API Model
        public static UserModel Map(Domain.Models.User user)
        {
            return new UserModel
            {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email,
                FromLocation = user.FromLocation,
                ProfilePicURL = user.ProfilePicURL,
                Likes = user.Likes
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.User Map(UserModel model)
        {
            return new Domain.Models.User
            {
                ID = model.ID,
                Name = model.Name,
                Email = model.Email,
                FromLocation = model.FromLocation,
                ProfilePicURL = model.ProfilePicURL,
                Likes = model.Likes
            };
        }
    }
}
