using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MuseumApp.DB.Repositories
{
    public class ArtworkRepository: IArtworkInterface
    {
        private readonly ArtApplicationContext _context;

        public ArtworkRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add Artwork
        public bool AddArtwork(Domain.Models.Artwork artwork)
        {
            var dbArtwork = _context.Artworks.FirstOrDefault(aw => aw.Title == artwork.Title);

            // Get the artwork by title, If the artist matches, do not add it.
            //    Possibly could change this, people could have their own versions.
            //if (dbArtwork.ArtistId == artwork.ArtistId)
            //{
            //    return false;
            //}

            _context.Artworks.Add(Mappers.ArtworkMapper.Map(artwork));
            _context.SaveChanges();

            return true;
        }

        // Delete Artwork
        public bool DeleteArtwork(int id)
        {
            var dbArtwork = _context.Artworks.FirstOrDefault(aw => aw.Id == id);

            if (dbArtwork == null)
            {
                return false;
            }

            _context.Artworks.Remove(dbArtwork);
            _context.SaveChanges();

            return true;
        }

        // Get All Artworks/Search by title for artwork
        public IEnumerable<Domain.Models.Artwork> GetAllArtworks(string title = null)
        {
            List<Artwork> dbArtworks = new List<Artwork>();

            if (!string.IsNullOrWhiteSpace(title))
            {
                dbArtworks = _context.Artworks.Where(aw => aw.Title.Contains(title)).ToList();
            }
            else
            {
                dbArtworks = _context.Artworks.ToList();
            }

            if (!dbArtworks.Any())
            {
                return new List<Domain.Models.Artwork>();
            }

            List<Domain.Models.Artwork> artworks = dbArtworks.Select(aw => Mappers.ArtworkMapper.Map(aw)).ToList();

            return artworks;
        }

        // Get Artworks by Artist
        public IEnumerable<Domain.Models.Artwork> GetArtworksByArtist(int artistId)
        {
            List<Artwork> dbArtworks = new List<Artwork>();

            try
            {
                dbArtworks = _context.Artworks.Where(ar => ar.ArtistId == artistId).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }

            var domainArtworks = dbArtworks.Select(Mappers.ArtworkMapper.Map);

            return domainArtworks; 
        }

        // Get Artworks by Adder
        public IEnumerable<Domain.Models.Artwork> GetArtworksByAdder(int adderId)
        {
            List<Artwork> dbArtworks = new List<Artwork>();

            try
            {
                dbArtworks = _context.Artworks.Where(ar => ar.ArtWorkAdderId == adderId).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }

            var domainArtworks = dbArtworks.Select(Mappers.ArtworkMapper.Map);

            return domainArtworks;
        }


        // Get artwork by ID
        public Domain.Models.Artwork GetArtworkByID(int id)
        {
            var dbArtwork = _context.Artworks.FirstOrDefault(aw => aw.Id == id);

            if (dbArtwork == null)
            {
                return null;
            }

            Domain.Models.Artwork artwork = Mappers.ArtworkMapper.Map(dbArtwork);

            return artwork;
        }

        // Edit Artwork
        public bool UpdateArtwork(Domain.Models.Artwork artwork)
        {
            var dbArtwork = _context.Artworks.FirstOrDefault(aw => aw.Id == artwork.Id);

            if (dbArtwork == null)
            {
                return false;
            }

            dbArtwork = Mappers.ArtworkMapper.Map(artwork);
            _context.SaveChanges();

            return true;
        }
    }
}
