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
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkInterface _artworkRepository;

        public ArtworkController(IArtworkInterface artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        // GET: api/artwork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkModel>>> Get([FromQuery] string title = null)
        {
            var domain_artworks = await Task.FromResult(_artworkRepository.GetAllArtworks(title));

            IEnumerable<ArtworkModel> artworkModels = domain_artworks.Select(Mappers.ArtworkModelMapper.Map);

            if (artworkModels.Any())
            {
                return Ok(artworkModels);
            }

            return NotFound();
        }

        // GET api/artwork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkModel>> Get([FromRoute]int id)
        {
            var domainArtwork = await Task.FromResult(_artworkRepository.GetArtworkByID(id));

            if (domainArtwork != null)
            {
                if (Mappers.ArtworkModelMapper.Map(domainArtwork) is ArtworkModel artworkModel)
                {
                    return Ok(artworkModel);
                }
            }

            return NotFound();
        }

        // POST api/artwork
        [HttpPost]
        public async Task<IActionResult> Post(ArtworkModel artworkModel)
        {
            var created = await Task.FromResult(_artworkRepository.AddArtwork(Mappers.ArtworkModelMapper.Map(artworkModel)));

            if (created)
            {
                return Ok();
            }

            return NotFound();
        }

        // PUT api/artwork/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int artworkId, [FromBody] ArtworkModel artworkModel)
        {
            var edited = await Task.FromResult(_artworkRepository.UpdateArtwork(Mappers.ArtworkModelMapper.Map(artworkModel)));

            if (edited)
            {
                return NoContent();
            }

            return BadRequest();
        }

        // DELETE api/artwork/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await Task.FromResult(_artworkRepository.DeleteArtwork(id));

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
