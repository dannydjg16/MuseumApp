using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILocationTypeInterface
    {
        public bool AddLocationType(LocationType locationType);
        public IEnumerable<LocationType> GetLocationTypes();
        public IEnumerable<LocationType> GetLocationTypesFull();
        public IEnumerable<LocationType> GetLocationTypesABC();
    }
}
