using System.Linq;

namespace MuseumApp.DB.Mappers
{
    public static class LocationMapper
    {
        // Put in Domain Model, Get back DB Model
        public static Location Map(Domain.Models.Location location)
        {
            return new Location
            {
                Id = location.Id,
                LocationName = location.LocationName,
                TypeId = location.TypeId,
                LocationUrl = location.LocationUrl,
                Description = location.Description
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.Location Map(Location entity)
        {
            return new Domain.Models.Location
            {
                Id = entity.Id,
                LocationName = entity.LocationName,
                TypeId = entity.TypeId,
                LocationUrl = entity.LocationUrl,
                Description = entity.Description,
                Artworks = entity.Artworks.Select(ArtworkMapper.Map)
            };
        }

        // Put in Domain Model, Get back DB Model
        public static Location MapFullNoArtworks(Domain.Models.Location location)
        {
            return new Location
            {
                Id = location.Id,
                LocationName = location.LocationName,
                TypeId = location.TypeId,
                LocationUrl = location.LocationUrl,
                Description = location.Description,
                Country = location.Country,
                StateProvince = location.StateProvince,
                City = location.City,
                StreetAddress = location.StreetAddress
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.Location MapFullNoArtworks(Location entity)
        {
            return new Domain.Models.Location
            {
                Id = entity.Id,
                LocationName = entity.LocationName,
                TypeId = entity.TypeId,
                LocationUrl = entity.LocationUrl,
                Description = entity.Description,
                Country = entity.Country,
                StateProvince = entity.StateProvince,
                City = entity.City,
                StreetAddress = entity.StreetAddress
            };
        }

        // Put in Domain Model, Get back DB Model
        public static Location MapFull(Domain.Models.Location location)
        {
            return new Location
            {
                Id = location.Id,
                LocationName = location.LocationName,
                TypeId = location.TypeId,
                LocationUrl = location.LocationUrl,
                Description = location.Description,
                Country = location.Country,
                StateProvince = location.StateProvince,
                City = location.City,
                StreetAddress = location.StreetAddress
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.Location MapFull(Location entity)
        {
            return new Domain.Models.Location
            {
                Id = entity.Id,
                LocationName = entity.LocationName,
                TypeId = entity.TypeId,
                LocationUrl = entity.LocationUrl,
                Description = entity.Description,
                Country = entity.Country,
                StateProvince = entity.StateProvince,
                City = entity.City,
                StreetAddress = entity.StreetAddress,
                Artworks = entity.Artworks.Select(ArtworkMapper.Map)
            };
        }
    }
}
