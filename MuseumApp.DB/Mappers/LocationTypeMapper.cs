namespace MuseumApp.DB.Mappers
{
    public static class LocationTypeMapper
    {
        // Put in Domain Model, Get back DB Model
        public static LocationType Map(Domain.Models.LocationType locationType)
        {
            return new LocationType
            {
                Id = locationType.Id,
                Name = locationType.Name
            };
        }

        // Put in DB Model, Get back Domain Model
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
