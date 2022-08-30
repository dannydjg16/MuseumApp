using System.Collections.Generic;

namespace MuseumApp.WebAPI.Models
{
    public class LocationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<LocationModel> Locations { get; set; }

    }
}
