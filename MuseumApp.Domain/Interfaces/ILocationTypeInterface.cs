using System;
using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILocationTypeInterface
    {
        public bool AddArtType(ArtType artType);
        public IEnumerable<ArtType> GetArtTypes();
    }
}
