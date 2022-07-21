namespace MuseumApp.DB.Mappers
{
    public static class ArtTypeMapper
    {
        // Put in Domain Model, Get back DB Model
        public static ArtType Map(Domain.Models.ArtType artType)
        {
            return new ArtType
            {
                Id = artType.Id,
                Name = artType.Name,
                Description = artType.Description
            };
        }

        // Put in DB Model, Get back Domain Model
        public static Domain.Models.ArtType Map(ArtType entity)
        {
            return new Domain.Models.ArtType
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}
