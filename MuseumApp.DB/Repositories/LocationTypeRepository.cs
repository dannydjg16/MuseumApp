using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class LocationTypeRepository: ILocationTypeInterface
    {
        private readonly ArtApplicationContext _context;

        public LocationTypeRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add Location Type
        public bool AddLocationType(Domain.Models.LocationType locationType)
        {
            var dbLocationType = _context.LocationTypes.FirstOrDefault(lt => lt.Name == locationType.Name);

            if (dbLocationType != null)
            {
                return false;
            }

            _context.Add(Mappers.LocationTypeMapper.Map(locationType));
            _context.SaveChanges();

            return true;
        }

        // Get Location Types
        public IEnumerable<Domain.Models.LocationType> GetLocationTypes()
        {
            List<LocationType> dbLocationTypes = new List<LocationType>();

            dbLocationTypes = _context.LocationTypes.ToList();

            List<Domain.Models.LocationType> locationTypes = dbLocationTypes.Select(lt => Mappers.LocationTypeMapper.Map(lt)).ToList();

            return locationTypes;
        }
    }
}
