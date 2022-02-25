﻿using System;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtworkModelMapper
    {
        public static ArtworkModel Map(Domain.Models.Artwork artwork)
        {
            return new ArtworkModel
            {
                Id = artwork.Id,
                Title = artwork.Title,
                ArtistId = artwork.ArtistId,
                Description = artwork.Description,
                FileName = artwork.FileName,
                Likes = artwork.Likes,
                LocationNow = artwork.LocationNow,
                MediumId = artwork.MediumId,
                YearCreated = artwork.YearCreated
            };
        }

        public static Domain.Models.Artwork Map(ArtworkModel model)
        {
            return new Domain.Models.Artwork
            {
                Id = model.Id,
                Title = model.Title,
                ArtistId = model.ArtistId,
                Description = model.Description,
                FileName = model.FileName,
                Likes = model.Likes,
                LocationNow = model.LocationNow,
                MediumId = model.MediumId,
                YearCreated = model.YearCreated
            };
        }
    }
}