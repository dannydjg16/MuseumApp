using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class LocationTypeModelMapper
    {
        public static LocationTypeModel Map(Domain.Models.LocationType locationType)
        {
            return new LocationTypeModel
            {
                Id = locationType.Id,
                Name = locationType.Name
            };
        }

        public static Domain.Models.LocationType Map(LocationTypeModel model)
        {
            return new Domain.Models.LocationType
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
