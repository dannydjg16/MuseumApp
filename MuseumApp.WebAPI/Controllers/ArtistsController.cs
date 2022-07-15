using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> Get()
        {
            var appArtists = await Task.FromResult(_artistRepository.GetArtists());

            if(appArtists.Select(Mappers.ArtistModelMapper.Map) is IEnumerable<ArtistModel> artists)
            {
                return Ok(artists);
            }

            return NotFound();
        }

        // GET: api/artists/abc
        [HttpGet("abc")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetABC()
        {
            var appArtists = await Task.FromResult(_artistRepository.GetArtistsABC());

            if (appArtists.Select(Mappers.ArtistModelMapper.Map) is IEnumerable<ArtistModel> artists)
            {
                return Ok(artists);
            }

            return NotFound();
        }

        // GET api/artists/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ArtistModel>> Get(int id)
        {
            var appArtist = await Task.FromResult(_artistRepository.GetArtistByID(id));
            //appArtist.Artworks = _artworkRepository.GetArtworksByArtist(id);

            if(Mappers.ArtistModelMapper.MapWithArtworks(appArtist) is ArtistModel artist)
            {
                return Ok(artist);
            }

            return NotFound();
        }

        // POST api/artists
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArtistModel artistModel)
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
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ArtistModel artistModel)
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
        [Authorize]
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
