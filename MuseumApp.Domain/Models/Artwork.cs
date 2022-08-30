using System;
using System.Collections.Generic;

namespace MuseumApp.Domain.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int? YearCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Likes { get; set; }
        public int ArtistId { get; set; }
        public int? MediumId { get; set; }
        public int? LocationNow { get; set; }
        public int? ArtWorkAdderId { get; set; }
        public DateTime? DateAdded { get; set; }

        public Artist Artist { get; set; }
        public Location Location { get; set; }
        public ArtType Medium { get; set; }
        public User ArtWorkAdder { get; set; }
        public IEnumerable<Like> LikesNavigation { get; set; }


        //Verify that the artwork was created in a valid year.
        public bool VerifyArtCreatedYear()
        {
            if (YearCreated > 2023)
            {
                return false;
            }
            else if (YearCreated < -60000)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Want to have this method contain all verification methods I add now and in the future.
        ///     When I add an artwork, want it to have to pass these validations.
        /// </summary>
        /// <returns></returns>
        public bool VerifyArtMethods()
        {
            // For now, 08/10/2022, just one method
            if (VerifyArtCreatedYear())
            {
                return true;
            }
            return false;
        }
    }
}
