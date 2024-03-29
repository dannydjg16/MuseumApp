﻿using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface IArtistInterface
    {
        bool CreateArtist(Artist artist);
        bool DeleteArtist(int artistID);
        bool EditArtist(Artist artist);
        IEnumerable<Artist> GetArtists(string artistName = null);
        IEnumerable<Artist> GetFullArtists(string artistName = null);
        IEnumerable<Artist> GetArtistsABC(string artistName = null);
        Artist GetArtistByID(int id);
        Artist GetFullArtistByID(int id);
    }
}
