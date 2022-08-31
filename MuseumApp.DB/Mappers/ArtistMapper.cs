using System.Linq;

namespace MuseumApp.DB.Mappers
{
    public static class ArtistMapper
    {
        // Put in DB Model, Get back Domain Model
        public static Domain.Models.Artist Map(Artist entity)
        {
            return new Domain.Models.Artist
            {
                Id = entity.Id,
                Name = entity.Name,
                BornLocation = entity.BornLocation,
                Biography = entity.Bio,
                PictureURL = entity.PictureUrl,
                Born = entity.Born,
                Died = entity.Died,
                ArtistAdderId = entity.ArtistAdderId,
                Artworks = entity.Artworks.Select(ArtworkMapper.Map)
            };
        }

        // Put in Domain Model, Get back DB Model
        public static Artist Map(Domain.Models.Artist model)
        {
            return new Artist
            {
                Id = model.Id,
                Name = model.Name,
                BornLocation = model.BornLocation,
                Bio = model.Biography,
                PictureUrl = model.PictureURL,
                Born = model.Born,
                Died = model.Died,
                ArtistAdderId = model.ArtistAdderId
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.Artist MapFull(Artist entity)
        {
            return new Domain.Models.Artist
            {
                Id = entity.Id,
                Name = entity.Name,
                BornLocation = entity.BornLocation,
                Biography = entity.Bio,
                PictureURL = entity.PictureUrl,
                Born = entity.Born,
                Died = entity.Died,
                ArtistAdderId = entity.ArtistAdderId,
                Artworks = entity.Artworks.Select(ArtworkMapper.Map),
                ArtistAdder = UserMapper.Map(entity.ArtistAdder)
            };
        }

        // Put in Domain Model, Get back DB Model
        // Can go from having ICollection(On Domain Model) to creating IEnumerable(On DBModel) without explicit cast, but cannot go IEnumerable -> ICollection without explicit cast
        public static Artist MapFull(Domain.Models.Artist model)
        {
            return new Artist
            {
                Id = model.Id,
                Name = model.Name,
                BornLocation = model.BornLocation,
                Bio = model.Biography,
                PictureUrl = model.PictureURL,
                Born = model.Born,
                Died = model.Died,
                ArtistAdderId = model.ArtistAdderId,
                Artworks = (System.Collections.Generic.ICollection<Artwork>)model.Artworks.Select(ArtworkMapper.Map),
                ArtistAdder = UserMapper.Map(model.ArtistAdder)
            };
        }
    }
}
