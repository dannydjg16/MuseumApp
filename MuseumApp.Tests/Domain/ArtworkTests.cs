using System;
using MuseumApp.Domain.Models;

namespace MuseumApp.Tests.Domain
{
    public class ArtworkTests
    {
        readonly Artwork TestArtwork = new Artwork
        {
            ArtistId = 1
        };

        [Theory]
        [InlineData(4000)]
        [InlineData(2023)]
        [InlineData(-60001)]
        [InlineData(0)]
        public void CheckArtYearIsNotLegitimate(int value)
        {
            TestArtwork.YearCreated = value;

            bool realAge = TestArtwork.VerifyArtCreatedYear();

            Assert.False(realAge);
        }

    }
}

