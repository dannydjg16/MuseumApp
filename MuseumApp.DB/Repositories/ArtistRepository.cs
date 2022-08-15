using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MuseumApp.DB.Mappers;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class ArtistRepository: IArtistInterface
    {
        private readonly ArtApplicationContext _context;

        public ArtistRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Create Artist
        public bool CreateArtist(Domain.Models.Artist artist)
        {
            try
            {
                _context.Artists.Add(Mappers.ArtistMapper.Map(artist));
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        // Delete Artist
        public bool DeleteArtist(int artistID)
        {
            try
            {

                var dbArtist = _context.Artists.SingleOrDefault(a => a.Id == artistID);

                if (dbArtist == null)
                {
                    return false;
                }

                _context.Artists.Remove(dbArtist);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }

        }

        // Edit Artist
        public bool EditArtist(Domain.Models.Artist artist)
        {
            try
            {
                var dbArtist = _context.Artists.SingleOrDefault(a => a.Id == artist.Id);

                if (dbArtist == null)
                {
                    return false;
                }

                // If dbartist name is NOT null or white space 
                if (!string.IsNullOrWhiteSpace(artist.Name))
                {
                    // Change the name 
                    dbArtist.Name = artist.Name;
                }

                // If dbartist PictureURL is NOT null or white space 
                if (!string.IsNullOrWhiteSpace(artist.PictureURL))
                {
                    // Change the PictureURL 
                    dbArtist.PictureUrl = artist.PictureURL;
                }

                // If dbartist BornLocation is NOT null or white space 
                if (!string.IsNullOrWhiteSpace(artist.BornLocation))
                {
                    // Change the BornLocation 
                    dbArtist.BornLocation = artist.BornLocation;
                }

                // If dbartist Born is NOT null or white space 
                if (-70000 <= artist.Born && artist.Born <= 2050)
                {
                    // Change the Born 
                    dbArtist.Born = artist.Born;
                }

                // If dbartist Died is NOT null or white space 
                if (-70000 <= artist.Died && artist.Died <= 2050)
                {
                    // Change the Died 
                    dbArtist.Died = artist.Died;
                }

                // If dbartist Bio is NOT null or white space 
                if (!string.IsNullOrWhiteSpace(artist.Biography))
                {
                    // Change the Bio 
                    dbArtist.Bio = artist.Biography;
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        // Get Artist by ID
        public Domain.Models.Artist GetArtistByID(int id)
        {
            try
            {
                var dbArtist = _context.Artists.SingleOrDefault(a => a.Id == id);
                var domainArtist = new Domain.Models.Artist();

                if (dbArtist == null)
                {
                    return null;
                }

                try
                {
                    domainArtist = ArtistMapper.Map(dbArtist);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not able to convert Databse Artist into Domain Artist" + e.Message);

                    return null;
                }

                return ArtistMapper.Map(dbArtist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return new Domain.Models.Artist();
            }
        }

        // Get all Artists/ Search by artist name
        public IEnumerable<Domain.Models.Artist> GetArtists(string artistName = null)
        {
            try
            {
                List<Artist> dbArtists;

                // If the string has writing, go in to block
                if (!string.IsNullOrWhiteSpace(artistName))
                {
                    dbArtists = _context.Artists.Where(a => a.Name.Contains(artistName)).ToList();
                }
                else
                {
                    dbArtists = _context.Artists.Include(artist => artist.Artworks).ToList();
                }

                // If there are no artists, go into block
                if (!dbArtists.Any())
                {
                    return new List<Domain.Models.Artist>();
                }

                List<Domain.Models.Artist> domainArtists = dbArtists.Select(a => ArtistMapper.Map(a)).ToList();

                return domainArtists;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return new List<Domain.Models.Artist>();
            }
        }

        // Get all Artists/ Search by artist name (Alphabetically)
        public IEnumerable<Domain.Models.Artist> GetArtistsABC(string artistName = null)
        {
            try
            {
                List<Artist> dbArtists;

                // If the string has writing, go in to block
                if (!string.IsNullOrWhiteSpace(artistName))
                {
                    dbArtists = _context.Artists.Where(a => a.Name.Contains(artistName)).ToList();
                }
                else
                {
                    dbArtists = _context.Artists.Include(artist => artist.Artworks).ToList();
                }

                // If there are no artists, go into block
                if (dbArtists.Any())
                {
                    List<Domain.Models.Artist> domainArtists = dbArtists.Select(a => ArtistMapper.Map(a)).ToList();

                    domainArtists = domainArtists.OrderBy(artist => artist.Name).ToList();

                    return domainArtists;
                }
                return new List<Domain.Models.Artist>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return new List<Domain.Models.Artist>();
            }
        }
    }
}
