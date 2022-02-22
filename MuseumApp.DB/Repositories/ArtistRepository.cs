using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool CreateArtist(Domain.Models.Artist artist)
        {
            var dbArtist = _context.Artists.FirstOrDefault(a => a.Id == artist.ID);

            if (dbArtist == null)
            {
                return false;
            }

            _context.Artists.Add(Mappers.ArtistMapper.Map(artist));
            _context.SaveChanges();

            return true;
        }

        public bool DeleteArtist(int artistID)
        {
            var dbArtist = _context.Artists.FirstOrDefault(a => a.Id == artistID);

            if (dbArtist == null)
            {
                return false;
            }

            _context.Artists.Remove(dbArtist);
            _context.SaveChanges();

            return true;
        }

        // Not really planning on using this so often. Maybe will change when I add more of a likes feature.
        //  Maybe could just have a add like func or a number of different ways to do it.
        public bool EditArtist(Domain.Models.Artist artist)
        {
            var dbArtist = _context.Artists.FirstOrDefault(a => a.Id == artist.ID);

            if (dbArtist == null)
            {
                return false;
            } else
            {
                dbArtist = ArtistMapper.Map(artist);

                return true;
            }


        }

        public Domain.Models.Artist GetArtistByID(int id)
        {
            var dbArtist = _context.Artists.FirstOrDefault(a => a.Id == id);
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
                Console.WriteLine("Not able to convert Databse Artist into Domain Artist", e);
                return null;
            }

            return ArtistMapper.Map(dbArtist);
        }

        public IEnumerable<Domain.Models.Artist> GetArtists(string artistName = null)
        {
            List<Artist> dbArtists = new List<Artist>();

            // If the string has writing, go in to block
            if (!string.IsNullOrWhiteSpace(artistName))
            {
                dbArtists = _context.Artists.Where(a => a.Name.Contains(artistName)).ToList();
            } else
            {
                dbArtists = _context.Artists.ToList();
            }

            // If there are no artists, go into block
            if (!dbArtists.Any())
            {
                return new List<Domain.Models.Artist>();
            }

            List<Domain.Models.Artist> domainArtists = dbArtists.Select(a => new Domain.Models.Artist
            {
                ID = a.Id,
                BornLocation = a.BornLocation,
                Biography = a.Bio,
                Name = a.Name,
                Born = a.Born,
                Died = a.Died,
                PictureURL = a.PictureUrl
            }).ToList();

            return domainArtists;
        }
    }
}
