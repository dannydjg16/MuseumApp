﻿using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILocationInterface
    {
        bool AddLocation(Location location);
        bool EditLocation(Location location);
        Location GetLocationById(int id);
        Location GetFullLocationById(int id);
        IEnumerable<Location> GetLocations(string name = null);
        IEnumerable<Location> GetFullLocations(string name = null);
        IEnumerable<Location> GetLocationsABC(string name = null);
    }
}
