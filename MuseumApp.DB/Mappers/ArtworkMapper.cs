namespace MuseumApp.DB.Mappers
{
    public static class ArtworkMapper
    {
        public static Artwork Map(Domain.Models.Artwork artwork)
        {
            return new Artwork
            {
                Id = artwork.Id,
                ArtistId = artwork.ArtistId,
                Description = artwork.Description,
                FileName = artwork.FileName,
                Likes = artwork.Likes,
                LocationNow = artwork.LocationNow,
                MediumId = artwork.MediumId,
                Title = artwork.Title,
                YearCreated = artwork.YearCreated,
                ArtWorkAdderId = artwork.ArtWorkAdderId
            };
        }

        public static Domain.Models.Artwork Map(Artwork entity)
        {
            return new Domain.Models.Artwork
            {
                Id = entity.Id,
                ArtistId = entity.ArtistId,
                Description = entity.Description,
                FileName = entity.FileName,
                Likes = entity.Likes,
                LocationNow = entity.LocationNow,
                MediumId = entity.MediumId,
                Title = entity.Title,
                YearCreated = entity.YearCreated,
                ArtWorkAdderId = entity.ArtWorkAdderId
            };
        }

        public static Artwork MapFull(Domain.Models.Artwork artwork)
        {
            return new Artwork
            {
                Id = artwork.Id,
                ArtistId = artwork.ArtistId,
                Description = artwork.Description,
                FileName = artwork.FileName,
                Likes = artwork.Likes,
                LocationNow = artwork.LocationNow,
                MediumId = artwork.MediumId,
                Title = artwork.Title,
                YearCreated = artwork.YearCreated,
                ArtWorkAdderId = artwork.ArtWorkAdderId,
                Artist = ArtistMapper.Map(artwork.Artist),
                LocationNowNavigation = LocationMapper.Map(artwork.Location),
                Medium = ArtTypeMapper.Map(artwork.Medium)
            };
        }

        public static Domain.Models.Artwork MapFull(Artwork entity)
        {
            return new Domain.Models.Artwork
            {
                Id = entity.Id,
                ArtistId = entity.ArtistId,
                Description = entity.Description,
                FileName = entity.FileName,
                Likes = entity.Likes,
                LocationNow = entity.LocationNow,
                MediumId = entity.MediumId,
                Title = entity.Title,
                YearCreated = entity.YearCreated,
                ArtWorkAdderId = entity.ArtWorkAdderId,
                Artist = ArtistMapper.Map(entity.Artist),
                Location = LocationMapper.Map(entity.LocationNowNavigation),
                Medium = ArtTypeMapper.Map(entity.Medium)

            };
        }
    }
}
