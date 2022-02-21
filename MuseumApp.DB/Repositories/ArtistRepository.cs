using System;
using System.Collections.Generic;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class ArtistRepository: IArtistInterface
    {

        public ArtistRepository()
        {
        }

        bool IArtistInterface.CreateArtist(Domain.Models.Artist artist)
        {
            throw new NotImplementedException();
        }

        bool IArtistInterface.DeleteArtist(int artistID)
        {
            throw new NotImplementedException();
        }

        bool IArtistInterface.EditArtist(Domain.Models.Artist artist)
        {
            throw new NotImplementedException();
        }

        Domain.Models.Artist IArtistInterface.GetArtistByID(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Domain.Models.Artist> IArtistInterface.GetArtists(string artistName)
        {
            throw new NotImplementedException();
        }
    }
}
