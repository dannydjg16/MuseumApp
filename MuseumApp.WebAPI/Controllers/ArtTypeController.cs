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
    public class ArtTypeController : ControllerBase
    {
        private readonly IArtTypeInterface _artTypeRespository;

        public ArtTypeController(IArtTypeInterface artTypeRepository)
        {
            _artTypeRespository = artTypeRepository;
        }

        // GET: api/arttype
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtTypeModel>>> Get()
        {
            var artTypes = await Task.FromResult(_artTypeRespository.GetArtTypes());

            if (artTypes.Select(Mappers.ArtTypeModelMapper.Map) is IEnumerable<ArtTypeModel> retrievedATMs)
            {
                return Ok(retrievedATMs);
            }

            return NotFound();
        }

        // POST api/arttype
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArtTypeModel artTypeModel) 
        {
            var complete = await Task.FromResult(_artTypeRespository.AddArtType(Mappers.ArtTypeModelMapper.Map(artTypeModel)));

            if (complete)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
