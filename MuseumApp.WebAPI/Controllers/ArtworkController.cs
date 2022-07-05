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
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkInterface _artworkRepository;

        public ArtworkController(IArtworkInterface artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        // GET: api/artwork
        [HttpGet]
        [Authorize]
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
        [Authorize]
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

        // GET api/artwork/5
        [HttpGet("full/{id}")]
        [Authorize]
        public async Task<ActionResult<ArtworkModel>> GetFull([FromRoute] int id)
        {
            var domainArtwork = await Task.FromResult(_artworkRepository.GetFullArtworkByID(id));

            if (domainArtwork != null)
            {
                if (Mappers.ArtworkModelMapper.MapFull(domainArtwork) is ArtworkModel artworkModel)
                {
                    return Ok(artworkModel);
                }
            }

            return NotFound();
        }

        // GET api/artwork/adder/5
        [HttpGet("adder/{id}")]
        [Authorize]
        public async Task<ActionResult<ArtworkModel>> GetArtByAdder([FromRoute] int id)
        {
            try
            {
                var domain_artworks = await Task.FromResult(_artworkRepository.GetArtworksByAdder(id));

                IEnumerable<ArtworkModel> artworkModels = domain_artworks.Select(Mappers.ArtworkModelMapper.Map);

                if (artworkModels.Any())
                {
                    return Ok(artworkModels);
                }
                else
                {
                    return NoContent();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/artwork/artist/5
        [HttpGet("artist/{id}")]
        [Authorize]
        public async Task<ActionResult<ArtworkModel>> GetArtByArtist([FromRoute] int id)
        {
            try {
                var domain_artworks = await Task.FromResult(_artworkRepository.GetArtworksByArtist(id));

                IEnumerable<ArtworkModel> artworkModels = domain_artworks.Select(Mappers.ArtworkModelMapper.Map);

                if (artworkModels.Any())
                {
                    return Ok(artworkModels);
                }
                else
                {
                    return NoContent();
                }
            } catch {
                return NotFound();
            }
        }

        // POST api/artwork
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArtworkModel artworkModel)
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
        [Authorize]
        public async Task<IActionResult> Put([FromBody] ArtworkModel artworkModel)
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
        [Authorize]
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
