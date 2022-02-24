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

        public bool AddArtType(Domain.Models.ArtType artType)
        {
            var dbArtType = _context.ArtTypes.FirstOrDefault(at => at.Name == artType.Name);

            // If the ArtType exists in the database, return false
            if (dbArtType != null)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Domain.Models.ArtType> GetArtTypes()
        {
            throw new NotImplementedException();
        }
    }
}
