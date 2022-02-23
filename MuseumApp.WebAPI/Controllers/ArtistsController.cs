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

        public ArtistsController(IArtistInterface artistRepository)
        {
            _artistRepository = artistRepository;
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

            if(Mappers.ArtistModelMapper.Map(appArtist) is ArtistModel artist)
            {
                return Ok(artist);
            }

            return NotFound();
        }

        // POST api/artists
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/artists/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/artists/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
