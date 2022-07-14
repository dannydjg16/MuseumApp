using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILocationTypeInterface
    {
        public bool AddLocationType(LocationType LocationType);
        public IEnumerable<LocationType> GetLocationTypes();
        public IEnumerable<LocationType> GetLocationTypesABC();
    }
}
