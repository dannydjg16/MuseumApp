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
        [InlineData(0)]
        public void CheckAgeIsNotLegitimate(int value)
        {
            TestArtist.Born = value;

            bool realAge = TestArtist.VerifyArtistBirthYear();

            Assert.False(realAge);
        }

        [Theory]
        [InlineData(2025)]
        [InlineData(2022)]
        [InlineData(-60000)]
        public void CheckAgeIsLegitimate(int value)
        {
            TestArtist.Born = value;

            bool realAge = TestArtist.VerifyArtistBirthYear();

            Assert.False(realAge);
        }
    }
}

