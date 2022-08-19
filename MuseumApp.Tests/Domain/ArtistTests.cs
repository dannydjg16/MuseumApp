using System;
using MuseumApp.Domain.Models;
using System.Collections.Generic;

namespace MuseumApp.Tests.Domain
{
    public class ArtistTests
    {
        readonly Artist TestArtist = new Artist
        {
            Artworks = new[] {
                new Artwork { Id = 1, Title = "Starry Night" },
                new Artwork { Id = 2, Title = "The Olive Trees" },
                new Artwork { Id = 3, Title = "Les Demoiselles d'Avignon" }
            }
        };

        [Fact]
        public void GetArtistsArtworkByID()
        {
            Assert.True(TestArtist.GetArtworkByID(1).Title == "Starry Night", "The chapters should have the same title");
        }

        [Fact]
        public void CheckArtworkCountIsCorrect()
        {

        }

        [Theory]
        [InlineData(4000)]
        [InlineData(2023)]
        [InlineData(-60001)]
        [InlineData(0)]
        public void CheckAgeIsNotLegitimate(int value)
        {
            TestArtist.Born = value;

            bool realAge = TestArtist.VerifyArtistBirthYear();

            Assert.False(realAge);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2022)]
        [InlineData(-60000)]
        public void CheckAgeIsLegitimate(int value)
        {
            TestArtist.Born = value;

            bool realAge = TestArtist.VerifyArtistBirthYear();

            Assert.True(realAge);
        }
    }
}

