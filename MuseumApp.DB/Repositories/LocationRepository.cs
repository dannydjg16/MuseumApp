using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class LocationRepository: ILocationInterface
    {
        private readonly ArtApplicationContext _context;

        public LocationRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add Location
        public bool AddLocation(Domain.Models.Location location)
        {
            var dbLocation = _context.Locations.FirstOrDefault(l => l.LocationName == location.LocationName);

            if (dbLocation != null)
            {
                return false;
            }

            _context.Locations.Add(Mappers.LocationMapper.Map(location));
            _context.SaveChanges();

            return true;
        }

        // Edit Location
        public bool EditLocation(Domain.Models.Location location)
        {
            var dbLocation = _context.Locations.FirstOrDefault(l => l.LocationName == location.LocationName);

            if (dbLocation == null)
            {
                return false;
            }

            dbLocation.TypeId = location.TypeId;
            _context.SaveChanges();

            return true;
        }

        // Get Location By ID
        public Domain.Models.Location GetLocationById(int id)
        {
            var dbLocation = _context.Locations.FirstOrDefault(l => l.Id == id);

            if (dbLocation == null)
            {
                return null;
            }

            return Mappers.LocationMapper.Map(dbLocation);
        }

        // Search Locations/Get all locations
        public IEnumerable<Domain.Models.Location> GetLocations(string name = null)
        {
            List<Location> dbLocations = new List<Location>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                dbLocations = _context.Locations.Where(l => l.LocationName.Contains(name)).ToList();
            }
            else
            {
                dbLocations = _context.Locations.ToList();
            }

            if (dbLocations.Any())
            {
                List<Domain.Models.Location> locations = dbLocations.Select(l => Mappers.LocationMapper.Map(l)).ToList();
                return locations;
            }

            return new List<Domain.Models.Location>();
        }
    }
}
