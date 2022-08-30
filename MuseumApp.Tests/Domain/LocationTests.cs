using System;
using MuseumApp.Domain.Models;

namespace MuseumApp.Tests.Domain
{
    public class LocationTests
    {
        readonly Location TestLocation = new Location
        {
            Artworks = new[] {
                new Artwork { Id = 1, Title = "Starry Night" },
                new Artwork { Id = 2, Title = "The Olive Trees" },
                new Artwork { Id = 3, Title = "Les Demoiselles d'Avignon" }
            }
        };

        [Fact]
        public void CheckArtworkCountIsCorrect()
        {
            Assert.True(TestLocation.GetArtworkCount() == 3, "The Location should have three artworks");
        }

    }
}

