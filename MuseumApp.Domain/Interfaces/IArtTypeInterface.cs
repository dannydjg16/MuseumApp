using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface IArtTypeInterface
    {
        public bool AddArtType(ArtType artType);
        public IEnumerable<ArtType> GetArtTypes();
    }
}
