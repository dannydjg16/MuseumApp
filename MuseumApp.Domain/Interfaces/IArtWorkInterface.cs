using System;
using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface IArtworkInterface
    {
        public Artwork GetArtworkByID(int id);
        public IEnumerable<Artwork> GetAllArtworks(string title = null);
        public bool UpdateArtwork(Artwork artwork);
        public bool AddArtwork(Artwork artwork);
        public bool DeleteArtwork(int id);
        public IEnumerable<Artwork> GetArtworksByArtist(int artistId);
        // Add methods for getting artwork by Type/Artist/etc.
    }
}
