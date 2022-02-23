using System;
using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface IArtworkInterface
    {
        public Artwork GetArtworkByID(int id);
        public IEnumerable<Artwork> GetAllArtworks();
        public bool UpdateArtwork(Artwork artwork);
        public bool AddArtwork();
        public bool DeleteArtwork();
        // Add methods for getting artwork by Type/Artist/etc.
    }
}
