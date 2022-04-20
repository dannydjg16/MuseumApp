using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class LikesRepository:ILikesInterface
    {
        private readonly ArtApplicationContext _context;

        public LikesRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        // Get Users Likes
        public IEnumerable<Domain.Models.Artwork> GetUsersLikes(int usersID)
        {
            return _context.Artworks
                .Include(u => u.LikesNavigation)
                .Where(aw => aw.LikesNavigation.Any(l => l.UserId == usersID))
                .Select(Mappers.ArtworkMapper.Map);
        }

        // Add New Like
        public bool LikeArtwork(int userID, int artworkID)
        {
            // Create the Like Model to add to DB
            var newLike = new Like
            {
                UserId = userID,
                ArtId = artworkID
            };

            // START process to increment like amount
            var dbArtwork = _context.Artworks.FirstOrDefault(aw => aw.Id == artworkID);

            if (dbArtwork == null)
            {
                return false;
            }

            if (dbArtwork.Likes == null)
            {
                dbArtwork.Likes = 1;
            }
            else
            {
                dbArtwork.Likes++;
            }
            // ^END process to increment like amount

            // Set the like
            _context.Likes.Add(newLike);
            _context.SaveChanges();

            return true;
        }

        // Delete Old Like
        public bool UnlikeArtwork(int userID, int artworkID)
        {
            var dbLike = _context.Likes.FirstOrDefault(like => like.ArtId == like.ArtId
                                                            && like.UserId == userID);

            _context.Likes.Remove(dbLike);
            _context.SaveChanges();

            return true;
        }
    }
}
