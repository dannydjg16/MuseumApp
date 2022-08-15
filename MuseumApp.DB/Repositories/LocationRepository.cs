using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                var dbLocation = _context.Locations.SingleOrDefault(l => l.LocationName == location.LocationName);

                if (dbLocation != null)
                {
                    return false;
                }

                _context.Locations.Add(Mappers.LocationMapper.MapFullNoArtworks(location));
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return false;
            }
        }

        // Edit Location
        public bool EditLocation(Domain.Models.Location location)
        {
            try
            {


                var dbLocation = _context.Locations.SingleOrDefault(l => l.Id == location.Id);

                if (dbLocation == null)
                {
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(location.LocationName))
                {
                    dbLocation.LocationName = location.LocationName;
                }

                if (!string.IsNullOrWhiteSpace(location.LocationUrl))
                {
                    dbLocation.LocationUrl = location.LocationUrl;
                }

                if (!string.IsNullOrWhiteSpace(location.Description))
                {
                    dbLocation.Description = location.Description;
                }

                if (!string.IsNullOrWhiteSpace(location.Country))
                {
                    dbLocation.Country = location.Country;
                }

                if (!string.IsNullOrWhiteSpace(location.StateProvince))
                {
                    dbLocation.StateProvince = location.StateProvince;
                }

                if (!string.IsNullOrWhiteSpace(location.City))
                {
                    dbLocation.City = location.City;
                }

                if (!string.IsNullOrWhiteSpace(location.StreetAddress))
                {
                    dbLocation.StreetAddress = location.StreetAddress;
                }

                if (location.TypeId != 0)
                {
                    dbLocation.TypeId = location.TypeId;
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return false;
            }
        }

        // Get Location By ID
        public Domain.Models.Location GetLocationById(int id)
        {
            try
            {
                var dbLocation = _context.Locations
                    .Include(l => l.Artworks)
                    .ThenInclude(aws => aws.Artist)
                    .SingleOrDefault(l => l.Id == id);

                if (dbLocation == null)
                {
                    return null;
                }

                return Mappers.LocationMapper.MapFullNoArtworks(dbLocation);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());

                return new Domain.Models.Location();
            }
        }

        // Search Locations/Get all locations
        public IEnumerable<Domain.Models.Location> GetLocations(string name = null)
        {
            try
            {
                List<Location> dbLocations;

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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return new List<Domain.Models.Location>();
            }
        }

        // Get Artworks in Location
        public IEnumerable<Domain.Models.Artwork> GetArtworksInLocation(int locationID)
        {
            try
            { 
                List<Artwork> dbArtworks = _context.Artworks.Where(ar => ar.LocationNow == locationID).ToList();

                var domainArtworks = dbArtworks.Select(Mappers.ArtworkMapper.Map);

                return domainArtworks;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());

                return new List<Domain.Models.Artwork>();
            }
        }

        // Sort the list alphabetically then return that list
        public IEnumerable<Domain.Models.Location> GetLocationsABC(string name = null)
        {
            try
            { 
                List<Location> dbLocations;

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

                    locations = locations.OrderBy(location => location.LocationName).ToList();

                    return locations;
                }

                return new List<Domain.Models.Location>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return new List<Domain.Models.Location>();
            }
        }
    }
}
