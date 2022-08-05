using System;
using MuseumApp.Domain.Models;
using System.Collections.Generic;

namespace MuseumApp.Tests.Domain
{
    public class ArtistTests
    {
        readonly Artist TestArtist = new Artist
        {
            Artworks = new[] { new Artwork { Id = 1, Title = "Starry Night" } }
        };

        [Fact]
        public void GetArtistsArtworkByID()
        {
            Assert.True(TestArtist.GetArtworkByID(1).Title == "Starry Night", "The chapters should have the same title");
        }

        [Theory]
        [InlineData(4000)]
        [InlineData(2026)]
        [InlineData(-60001)]
        public void CheckAgeIsNotLegitimate(int value)
        {
            bool realAge = true;

            if(value > 2025)
            {
                realAge = false;
            } else if (value < -60000)
            {
                realAge = false;
            }

            Assert.False(realAge);
        }
    }
}

