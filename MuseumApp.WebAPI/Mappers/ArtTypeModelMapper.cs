using System;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.WebAPI.Mappers
{
    public static class ArtTypeModelMapper
    {
        public static ArtTypeModel Map(Domain.Models.ArtType artType)
        {
            return new ArtTypeModel
            {
                Description = artType.Description,
                Id = artType.Id,
                Name = artType.Name
            };
        }

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
