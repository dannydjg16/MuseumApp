using System.Collections.Generic;
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
                CurrentCity = entity.CurrentCity,
                CurrentCountry = entity.CurrentCountry,
                CurrentStateProvince = entity.CurrentStateProvince,
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
                CurrentCity = model.CurrentCity,
                CurrentCountry = model.CurrentCountry,
                CurrentStateProvince = model.CurrentStateProvince,
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.User MapFull(User entity)
        {
            return new Domain.Models.User
            {
                ID = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                FromLocation = entity.FromLocation,
                ProfilePicURL = entity.ProfilePicUrl,
                CurrentCity = entity.CurrentCity,
                CurrentCountry = entity.CurrentCountry,
                CurrentStateProvince = entity.CurrentStateProvince,
                Likes = entity.Likes.Select(LikeMapper.Map),
                Artists = entity.Artists.Select(ArtistMapper.Map),
                Artworks = entity.Artworks.Select(ArtworkMapper.Map)
            };
        }

        // Put in Domain Model, Get back DB Model
        // Can go from having ICollection(On Domain Model) to creating IEnumerable(On DBModel) without explicit cast,
        //      but cannot go IEnumerable(On DBModel) -> ICollection(On Domain Model) without explicit cast
        public static User MapFull(Domain.Models.User model)
        {
            return new User
            {
                Id = model.ID,
                Name = model.Name,
                Email = model.Email,
                FromLocation = model.FromLocation,
                ProfilePicUrl = model.ProfilePicURL,
                CurrentCity = model.CurrentCity,
                CurrentCountry = model.CurrentCountry,
                CurrentStateProvince = model.CurrentStateProvince,
                Likes = (ICollection<Like>)model.Likes.Select(LikeMapper.Map),
                Artists = (ICollection<Artist>)model.Artists.Select(ArtistMapper.Map),
                Artworks = (ICollection<Artwork>)model.Artworks.Select(ArtworkMapper.Map)
            };
        }
    }
}
