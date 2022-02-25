﻿using System;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class LocationModelMapper
    {
        public static LocationModel Map(Domain.Models.Location location)
        {
            return new LocationModel
            {
                Id = location.Id,
                LocationName = location.LocationName,
                LocationUrl = location.LocationName,
                Description = location.Description,
                TypeId = location.TypeId
            };
        }

        public static Domain.Models.Location Map(LocationModel model)
        {
            return new Domain.Models.Location
            {
                Id = model.Id,
                LocationName = model.LocationName,
                LocationUrl = model.LocationName,
                Description = model.Description,
                TypeId = model.TypeId
            };
        }
    }
}