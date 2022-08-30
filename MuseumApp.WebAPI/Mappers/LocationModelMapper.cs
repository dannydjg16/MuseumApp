using System.Linq;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class LocationModelMapper
    {
        // Put in Domain Model, return API Model
        public static LocationModel Map(Domain.Models.Location location)
        {
            return new LocationModel
            {
                Id = location.Id,
                LocationName = location.LocationName,
                LocationUrl = location.LocationUrl,
                Description = location.Description,
                TypeId = location.TypeId,
                Artworks = location.Artworks.Select(ArtworkModelMapper.Map),
                ArtworkCount = location.GetArtworkCount()
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Location Map(LocationModel model)
        {
            return new Domain.Models.Location
            {
                Id = model.Id,
                LocationName = model.LocationName,
                LocationUrl = model.LocationUrl,
                Description = model.Description,
                TypeId = model.TypeId,
                Artworks = model.Artworks.Select(ArtworkModelMapper.Map)
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Location MapNoArtworks(LocationModel model)
        {
            return new Domain.Models.Location
            {
                Id = model.Id,
                LocationName = model.LocationName,
                LocationUrl = model.LocationUrl,
                Description = model.Description,
                TypeId = model.TypeId
            };
        }

        // Put in Domain Model, return API Model
        public static LocationModel MapFull(Domain.Models.Location location)
        {
            return new LocationModel
            {
                Id = location.Id,
                LocationName = location.LocationName,
                LocationUrl = location.LocationUrl,
                Description = location.Description,
                TypeId = location.TypeId,
                Artworks = location.Artworks.Select(ArtworkModelMapper.Map),
                Country = location.Country,
                StateProvince = location.StateProvince,
                City = location.City,
                StreetAddress = location.StreetAddress,
                ArtworkCount = location.GetArtworkCount()
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Location MapFull(LocationModel model)
        {
            return new Domain.Models.Location
            {
                Id = model.Id,
                LocationName = model.LocationName,
                LocationUrl = model.LocationUrl,
                Description = model.Description,
                TypeId = model.TypeId,
                Artworks = model.Artworks.Select(ArtworkModelMapper.Map),
                Country = model.Country,
                StateProvince = model.StateProvince,
                City = model.City,
                StreetAddress = model.StreetAddress
            };
        }

        // Put in Domain Model, return API Model
        public static LocationModel MapFullNoArtworks(Domain.Models.Location location)
        {
            return new LocationModel
            {
                Id = location.Id,
                LocationName = location.LocationName,
                LocationUrl = location.LocationUrl,
                Description = location.Description,
                TypeId = location.TypeId,
                Country = location.Country,
                StateProvince = location.StateProvince,
                City = location.City,
                StreetAddress = location.StreetAddress
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.Location MapFullNoArtworks(LocationModel model)
        {
            return new Domain.Models.Location
            {
                Id = model.Id,
                LocationName = model.LocationName,
                LocationUrl = model.LocationUrl,
                Description = model.Description,
                TypeId = model.TypeId,
                Country = model.Country,
                StateProvince = model.StateProvince,
                City = model.City,
                StreetAddress = model.StreetAddress
            };
        }
    }
}
