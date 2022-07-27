using MuseumApp.WebAPI.Models;
using System.Linq;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtistModelMapper
    {
        // Put in Domain Model, return API Model
        public static ArtistModel Map(Domain.Models.Artist artist)
        {
            return new ArtistModel
            {
                Id = artist.Id,
                Biography = artist.Biography,
                Born = artist.Born,
                Died = artist.Died,
                BornLocation = artist.BornLocation,
                Name = artist.Name,
                PictureURL = artist.PictureURL,
                ArtistAdderId = artist.ArtistAdderId,
                Artworks = artist.Artworks.Select(ArtworkModelMapper.Map)
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Artist Map(ArtistModel model)
        {
            return new Domain.Models.Artist
            {
                Id = model.Id,
                Biography = model.Biography,
                Born = model.Born,
                Died = model.Died,
                BornLocation = model.BornLocation,
                Name = model.Name,
                PictureURL = model.PictureURL,
                ArtistAdderId = model.ArtistAdderId
            };
        }

        // Put in Domain Model, return API Model
        public static ArtistModel MapWithArtworks(Domain.Models.Artist artist)
        {
            return new ArtistModel
            {
                Id = artist.Id,
                Biography = artist.Biography,
                Born = artist.Born,
                Died = artist.Died,
                BornLocation = artist.BornLocation,
                Name = artist.Name,
                PictureURL = artist.PictureURL,
                ArtistAdderId = artist.ArtistAdderId,
                Artworks = artist.Artworks.Select(ArtworkModelMapper.Map)
            };
        }
    }
}
