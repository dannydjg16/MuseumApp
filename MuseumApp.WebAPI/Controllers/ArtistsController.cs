using System;
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

        public ArtistsController(IArtistInterface artistRepository)
        {
            _artistRepository = artistRepository;
        }

        // GET: api/artists
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> Get()
        {
            try
            {
                var appArtists = await Task.FromResult(_artistRepository.GetArtists());

                if (appArtists.Select(Mappers.ArtistModelMapper.Map) is IEnumerable<ArtistModel> artists)
                {
                    return Ok(artists);
                }

                return NotFound();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // GET api/artists/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ArtistModel>> Get(int id)
        {
            try
            {
                var appArtist = await Task.FromResult(_artistRepository.GetArtistByID(id));

                if (Mappers.ArtistModelMapper.MapWithArtworks(appArtist) is ArtistModel artist)
                {
                    return Ok(artist);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // GET: api/artists/abc
        [HttpGet("abc")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetABC()
        {
            try
            {
                var appArtists = await Task.FromResult(_artistRepository.GetArtistsABC());

                if (appArtists.Select(Mappers.ArtistModelMapper.Map) is IEnumerable<ArtistModel> artists)
                {
                    return Ok(artists);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // POST api/artists
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArtistModel artistModel)
        {
            try
            {
                var success = await Task.FromResult(_artistRepository.CreateArtist(Mappers.ArtistModelMapper.Map(artistModel)));

                if (success)
                {
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // PUT api/artists/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ArtistModel artistModel)
        {
            try
            {
                var pass = await Task.FromResult(_artistRepository.EditArtist(Mappers.ArtistModelMapper.Map(artistModel)));

                if (pass)
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return BadRequest();
            }
        }

        // DELETE api/artists/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pass = await Task.FromResult(_artistRepository.DeleteArtist(id));

                if (pass)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // Using this to show what headers are allowed on this endpoint I believe
        // OPTIONS api/artists
        [HttpOptions]
        [Authorize]
        public async Task<IActionResult> Options()
        {
            var headers = await Task.FromResult(HttpContext.Response.Headers);
            return Ok(headers);
        }
    }
}
