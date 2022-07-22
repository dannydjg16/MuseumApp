using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtTypeModelMapper
    {
        // Put in Domain Model, return API Model
        public static ArtTypeModel Map(Domain.Models.ArtType artType)
        {
            return new ArtTypeModel
            {
                Description = artType.Description,
                Id = artType.Id,
                Name = artType.Name
            };
        }

        // Put in API Model, return Domain Model
        public static Domain.Models.ArtType Map(ArtTypeModel model)
        {
            return new Domain.Models.ArtType
            {
                Description = model.Description,
                Id = model.Id,
                Name = model.Name
            };
        }
        
    }
}
