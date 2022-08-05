﻿using System.Collections.Generic;
using System.Linq;

namespace MuseumApp.Domain.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public int? Born { get; set; }
        public int? Died { get; set; }
        public int? ArtistAdderId { get; set; }
        public IEnumerable<Artwork> Artworks { get; set; }

        public Artwork GetArtworkByID(int id)
        {
            return Artworks.FirstOrDefault(aw => aw.Id == id);
        }

        public bool VerifyArtistAge(int yearBorn)
        {
            if (yearBorn > 2025)
            {
                return false;
            }
            else if (yearBorn < -60000)
            {
                 return false;
            }
            return true;
        }
    }
}
