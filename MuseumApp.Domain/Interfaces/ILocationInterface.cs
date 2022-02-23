using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILocationInterface
    {
        bool AddLocation(Location location);
        bool EditLocation(Location location);
        bool DeleteLocation(int id);
        Location GetLocationById(int id);
        IEnumerable<Location> GetLocations(string name = null);
    }
}
