using System.Linq;
namespace MuseumApp.DB.Mappers
{
    public static class ArtistMapper
    {
        public static Domain.Models.Artist Map(Artist entity)
        {
            return new Domain.Models.Artist
            {
                ID = entity.Id,
                Name = entity.Name,
                BornLocation = entity.BornLocation,
                Biography = entity.Bio,
                PictureURL = entity.PictureUrl,
                Born = entity.Born,
                Died = entity.Died,
                Artworks = entity.Artworks.Select(ArtworkMapper.Map)
            };
        }

        public static Artist Map(Domain.Models.Artist model)
        {
            return new Artist
            {
                Id = model.ID,
                Name = model.Name,
                BornLocation = model.BornLocation,
                Bio = model.Biography,
                PictureUrl = model.PictureURL,
                Born = model.Born,
                Died = model.Died
            };
        }
    }
}
