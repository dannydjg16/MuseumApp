﻿using System;
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
                PictureURL = artist.PictureURL
            };
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
                PictureURL = model.PictureURL
            };
        }
    }
}