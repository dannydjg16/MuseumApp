namespace MuseumApp.DB.Mappers
{
    public static class ArtTypeMapper
    {
        public static ArtType Map(Domain.Models.ArtType artType)
        {
            return new ArtType
            {
                Id = artType.Id,
                Name = artType.Name,
                Description = artType.Description
            };
        }

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
