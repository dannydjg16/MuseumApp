using System;
using MuseumApp.WebAPI.Models;

namespace MuseumApp.Tests.API
{
    public class ArtworkModelTests
    {
        readonly ArtworkModel TestArtwork = new ArtworkModel
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

        [Theory]
        [InlineData(1)]
        [InlineData(2022)]
        [InlineData(-60000)]
        public void CheckArtYearIsLegitimate(int value)
        {
            TestArtwork.YearCreated = value;

            bool realAge = TestArtwork.VerifyArtCreatedYear();

            Assert.True(realAge);
        }
    }
}

