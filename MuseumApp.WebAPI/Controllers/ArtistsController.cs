using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumApp.Domain.Interfaces;
using MuseumApp.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MuseumApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistInterface _artistRepository;
        private readonly IArtworkInterface _artworkRepository;

        public ArtistsController(IArtistInterface artistRepository, IArtworkInterface artworkRepository)
        {
            _artistRepository = artistRepository;
            _artworkRepository = artworkRepository;
        }

        // GET: api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> Get()
        {
            var appArtists = await Task.FromResult(_artistRepository.GetArtists());

            if(appArtists.Select(Mappers.ArtistModelMapper.Map) is IEnumerable<ArtistModel> artists)
            {
                return Ok(artists);
            }
            return NotFound();
        }

        // GET api/artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var appArtist = await Task.FromResult(_artistRepository.GetArtistByID(id));
            appArtist.Artworks = _artworkRepository.GetArtworksByArtist(id);

            if(Mappers.ArtistModelMapper.Map(appArtist) is ArtistModel artist)
            {
                return Ok(artist);
            }

            return NotFound();
        }

        // POST api/artists
        [HttpPost]
        public async Task<IActionResult> Post(ArtistModel artistModel)
        {
            var success = await Task.FromResult(_artistRepository.CreateArtist(Mappers.ArtistModelMapper.Map(artistModel)));

            if (success == true)
            {
                return Ok();
            }

            return NotFound();
        }

        // PUT api/artists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int artistId, [FromBody] ArtistModel artistModel)
        {
            var pass = await Task.FromResult(_artistRepository.EditArtist(Mappers.ArtistModelMapper.Map(artistModel)));

            if (pass == true)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pass = await Task.FromResult(_artistRepository.DeleteArtist(id));

            if (pass == true)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
