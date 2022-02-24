using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class ArtTypeRepository: IArtTypeInterface
    {
        private readonly ArtApplicationContext _context;

        public ArtTypeRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add ArtType
        public bool AddArtType(Domain.Models.ArtType artType)
        {
            var dbArtType = _context.ArtTypes.FirstOrDefault(at => at.Name == artType.Name);

            // If the ArtType exists in the database, return false
            if (dbArtType != null)
            {
                return false;
            }

            _context.ArtTypes.Add(Mappers.ArtTypeMapper.Map(artType));
            _context.SaveChanges();

            return true;
        }

        // Get all ArtTypes
        public IEnumerable<Domain.Models.ArtType> GetArtTypes()
        {
            List<ArtType> dbArtTypes = _context.ArtTypes.ToList();

            if (!dbArtTypes.Any())
            {
                return new List<Domain.Models.ArtType>();
            }

            List<Domain.Models.ArtType> artTypes = dbArtTypes.Select(at => new Domain.Models.ArtType
            {
                Id = at.Id,
                Name = at.Name,
                Description = at.Description
            }).ToList();

            return artTypes;
        }
    }
}
