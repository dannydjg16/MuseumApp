﻿using System;
using System.Collections.Generic;
using System.Linq;
using MuseumApp.DB.Mappers;
using MuseumApp.Domain.Interfaces;

namespace MuseumApp.DB.Repositories
{
    public class ArtTypeRepository: IArtTypeInterface
    {
        private readonly ArtApplicationContext _context;

        public ArtTypeRepository(ArtApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Add ArtType
        public bool AddArtType(Domain.Models.ArtType artType)
        {
            try
            {
                var dbArtType = _context.ArtTypes.SingleOrDefault(at => at.Name == artType.Name);

                // If the ArtType exists in the database, return false
                if (dbArtType != null)
                {
                    return false;
                }

                _context.ArtTypes.Add(Mappers.ArtTypeMapper.Map(artType));
                _context.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return false;
            }
        }

        // Get all ArtTypes
        public IEnumerable<Domain.Models.ArtType> GetArtTypes()
        {
            try
            {
                List<ArtType> dbArtTypes = _context.ArtTypes.ToList();

                if (dbArtTypes.Any())
                {
                    List<Domain.Models.ArtType> artTypes = dbArtTypes.Select(at => ArtTypeMapper.Map(at)).ToList();

                    return artTypes;
                }

                return new List<Domain.Models.ArtType>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return new List<Domain.Models.ArtType>();
            }
        }

        // Get all ArtTypes Alphabetically
        public IEnumerable<Domain.Models.ArtType> GetArtTypesABC()
        {
            try
            {
                List<ArtType> dbArtTypes = _context.ArtTypes.ToList();

                if (dbArtTypes.Any())
                {
                    List<Domain.Models.ArtType> artTypes = dbArtTypes.Select(at => ArtTypeMapper.Map(at)).ToList();

                    artTypes = artTypes.OrderBy(at => at.Name).ToList();

                    return artTypes;
                }

                return new List<Domain.Models.ArtType>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return new List<Domain.Models.ArtType>();
            }
        }

        public IEnumerable<Domain.Models.ArtType> GetFullArtTypes()
        {
            try
            {
                List<ArtType> dbArtTypes = _context.ArtTypes.ToList();

                if (dbArtTypes.Any())
                {
                    List<Domain.Models.ArtType> artTypes = dbArtTypes.Select(at => ArtTypeMapper.Map(at)).ToList();

                    return artTypes;
                }

                return new List<Domain.Models.ArtType>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return new List<Domain.Models.ArtType>();
            }
        }
    }
}
