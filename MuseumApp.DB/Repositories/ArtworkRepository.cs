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
                dbArtworks = _context.Artworks.Include(a => a.Artist).Where(aw => aw.Title.Contains(title)).ToList();
            }
            else
            {
                dbArtworks = _context.Artworks.Include(a => a.Artist).ToList();
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

        // Get Full artwork by ID
        public Domain.Models.Artwork GetFullArtworkByID(int id)
        {
            var dbArtwork = _context.Artworks.Include(aw => aw.Artist).FirstOrDefault(aw => aw.Id == id);

            if (dbArtwork == null)
            {
                return null;
            }

            Domain.Models.Artwork artwork = Mappers.ArtworkMapper.MapWithArtist(dbArtwork);

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

            // If artwork title is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(artwork.Title))
            {
                // Change the title 
                dbArtwork.Title = artwork.Title;
            }

            // If filename filename is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(artwork.FileName))
            {
                // Change the filename 
                dbArtwork.FileName = artwork.FileName;
            }

            if (-70000 <= artwork.YearCreated && artwork.YearCreated <= 2050)
            {
                dbArtwork.YearCreated = artwork.YearCreated;
            }

            // If description Description is NOT null or white space 
            if (!string.IsNullOrWhiteSpace(artwork.Description))
            {
                // Change the Description 
                dbArtwork.Description = artwork.Description;
            }

            if (artwork.ArtistId != 0)
            {
                dbArtwork.ArtistId = artwork.ArtistId;
            }

            if (artwork.MediumId != 0)
            {
                dbArtwork.MediumId = artwork.MediumId;
            }

            if (artwork.LocationNow != 0)
            {
                dbArtwork.LocationNow = artwork.LocationNow;
            }

            _context.SaveChanges();

            return true;
        }
    }
}
