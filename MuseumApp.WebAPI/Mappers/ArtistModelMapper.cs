using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtistModelMapper
    {
        public static ArtistModel Map(Domain.Models.Artist artist)
        {
            return new ArtistModel
            {
                ID = artist.ID,
                Biography = artist.Biography,
                Born = artist.Born,
                Died = artist.Died,
                BornLocation = artist.BornLocation,
                Name = artist.Name,
                PictureURL = artist.PictureURL,
                ArtistAdderId = artist.ArtistAdderId
            };
        }


        public static ArtistModel MapWithArtworks(Domain.Models.Artist artist)
        {
            if (artist == null)
            {
                return new ArtistModel
                {
                    ID = artist.ID,
                    Biography = artist.Biography,
                    Born = artist.Born,
                    Died = artist.Died,
                    BornLocation = artist.BornLocation,
                    Name = artist.Name,
                    PictureURL = artist.PictureURL,
                    ArtistAdderId = artist.ArtistAdderId
                    //Artworks = new List<ArtworkModel>()
                };
            } else
            {
                return new ArtistModel
                {
                    ID = artist.ID,
                    Biography = artist.Biography,
                    Born = artist.Born,
                    Died = artist.Died,
                    BornLocation = artist.BornLocation,
                    Name = artist.Name,
                    PictureURL = artist.PictureURL,
                    ArtistAdderId = artist.ArtistAdderId
                    // Artworks = artist.Artworks.Select(ArtworkModelMapper.Map)
                };
            }
        }

        public static Domain.Models.Artist Map(ArtistModel model)
        {
            return new Domain.Models.Artist
            {
                ID = model.ID,
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
