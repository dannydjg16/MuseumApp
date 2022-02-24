using System;
namespace MuseumApp.DB.Mappers
{
    public static class LocationMapper
    {
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

        public static Domain.Models.Location Map(Location entity)
        {
            return new Domain.Models.Location
            {
                Id = entity.Id,
                LocationName = entity.LocationName,
                TypeId = entity.TypeId,
                LocationUrl = entity.LocationUrl,
                Description = entity.Description
            };
        }
    }
}
