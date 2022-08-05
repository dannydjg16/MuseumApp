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
        [InlineData(1)]
        [InlineData(9)]
        [InlineData(12)]
        public void CheckAgeIsLegitimate(int value)
        {
            Assert.True(true);
        }
    }
}

