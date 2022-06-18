using MuseumApp.WebAPI.Models;
using System.Linq;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtistModelMapper
    {
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


        public static ArtistModel MapWithArtworks(Domain.Models.Artist artist)
        {
            if (artist == null)
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
            } else
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
    }
}
