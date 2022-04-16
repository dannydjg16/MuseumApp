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
            //return _context.Likes.Include(like => like.Art)
            //    .Select(Mappers.LikeMapper.Map)
            //    .Where(like => usersID == like.UserId)
            //    .ToList();

            //return _context.Artworks.Include(u => u.Likes)
            //    .Where(aw => )
            //    .Select(aw => Mappers.ArtworkMapper.Map(aw))
            //    .Where(like => usersID == like.)
            //    .ToList();

            //return _context.Artworks.Include(u => u.LikesNavigation.Where(like => usersID == like.UserId))
            //    .Select(aw => Mappers.ArtworkMapper.Map(aw)).ToList();

            return _context.Artworks.Include(u => u.LikesNavigation)
                .Where(aw => aw.LikesNavigation.Any(l => l.UserId == usersID))
                .Select(Mappers.ArtworkMapper.Map);
        }

        // POST New Like
        public bool LikeArtwork(int userID, int artworkID)
        {
            var newLike = new Like
            {
                UserId = userID,
                ArtId = artworkID
            };

            // Set the like
            _context.Likes.Add(newLike);
            _context.SaveChanges();

            return true;
        }

        // DELETE Old Like
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
