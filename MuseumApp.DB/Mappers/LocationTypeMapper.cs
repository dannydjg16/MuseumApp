using System.Collections.Generic;
using System.Linq;
using MuseumApp.Domain.Models;

namespace MuseumApp.DB.Mappers
{
    public static class LocationTypeMapper
    {
        // Put in Domain Model, Get back DB Model
        public static LocationType Map(Domain.Models.LocationType locationType)
        {
            return new LocationType
            {
                Id = locationType.Id,
                Name = locationType.Name
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.LocationType Map(LocationType entity)
        {
            return new Domain.Models.LocationType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        // Put in Domain Model, Get back DB Model
        // Can go from having ICollection(On Domain Model) to creating IEnumerable(On DBModel) without explicit cast,
        //      but cannot go IEnumerable(On DBModel) -> ICollection(On Domain Model) without explicit cast
        public static LocationType MapFull(Domain.Models.LocationType locationType)
        {
            return new LocationType
            {
                Id = locationType.Id,
                Name = locationType.Name,
                Locations = (ICollection<Location>)locationType.Locations.Select(LocationMapper.Map)
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.LocationType MapFull(LocationType entity)
        {
            return new Domain.Models.LocationType
            {
                Id = entity.Id,
                Name = entity.Name,
                Locations = entity.Locations.Select(LocationMapper.Map)
            };
        }
    }
}
