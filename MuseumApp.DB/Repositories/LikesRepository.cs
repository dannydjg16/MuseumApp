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
        public IEnumerable<Domain.Models.Artwork> GetUsersLikes(int userID)
        {
            try
            {
                return _context.Artworks
                    .Include(u => u.LikesNavigation)
                    .Where(aw => aw.LikesNavigation.Any(l => l.UserId == userID))
                    .Select(Mappers.ArtworkMapper.Map);

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new List<Domain.Models.Artwork>();
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

            var dbLike = _context.Likes.SingleOrDefault(like => like.ArtId == artworkID
                                                            && like.UserId == userID);

            // START process to increment like amount
            var dbArtwork = _context.Artworks.SingleOrDefault(aw => aw.Id == artworkID);

            // If the artwork is not found OR the like IS found, return false
            if (dbArtwork == null || dbLike is not null)
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
            var dbLike = _context.Likes.SingleOrDefault(like => like.ArtId == artworkID
                                                            && like.UserId == userID);

            // START process to decrement like amount
            var dbArtwork = _context.Artworks.SingleOrDefault(aw => aw.Id == artworkID);

            // If the artwork is not found OR the like is not found, return false
            if (dbArtwork == null || dbLike == null)
            {
                return false;
            }
            // Should never be called with null likes
            if (dbArtwork.Likes == null)
            {
                dbArtwork.Likes = 0;
            }
            else
            {
                dbArtwork.Likes = dbArtwork.Likes - 1;
            }
            // ^END process to decrement like amount


            _context.Likes.Remove(dbLike);
            _context.SaveChanges();

            return true;
        }
    }
}
