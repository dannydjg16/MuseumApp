using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class LocationType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
