namespace MuseumApp.DB.Mappers
{
    public static class LocationTypeMapper
    {
        public static LocationType Map(Domain.Models.LocationType locationType)
        {
            return new LocationType
            {
                Id = locationType.Id,
                Name = locationType.Name
            };
        }

        public static Domain.Models.LocationType Map(LocationType entity)
        {
            return new Domain.Models.LocationType
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
