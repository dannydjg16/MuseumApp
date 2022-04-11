using System.Collections.Generic;
using MuseumApp.Domain.Models;

namespace MuseumApp.Domain.Interfaces
{
    public interface ILikesInterface
    {
        public IEnumerable<Artwork> GetUsersLikes(int userID);
        public bool LikeArtwork(int userID, int artworkID);
        public bool UnlikeArtwork(int userID, int artworkID);
    }
}
