using System.Collections.Generic;
using System.Linq;

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

        // Put in Domain Model, Get back DB Model
        // Can go from having ICollection to creating IEnumerable without explicit cast, but cannot go IEnumerable -> ICollection without explicit cast
        public static ArtType MapFull(Domain.Models.ArtType artType)
        {
            return new ArtType
            {
                Id = artType.Id,
                Name = artType.Name,
                Description = artType.Description,
                Artworks = (ICollection<Artwork>)artType.Artworks.Select(ArtworkMapper.Map)
            };
        }
    }
}
