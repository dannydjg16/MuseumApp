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
            try
            {
                var artTypes = await Task.FromResult(_artTypeRespository.GetArtTypes());

                if (artTypes.Select(Mappers.ArtTypeModelMapper.Map) is IEnumerable<ArtTypeModel> retrievedATMs)
                {
                    return Ok(retrievedATMs);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // GET: api/arttype/abc
        [HttpGet("abc")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtTypeModel>>> GetABC()
        {
            try
            {
                var artTypes = await Task.FromResult(_artTypeRespository.GetArtTypesABC());

                if (artTypes.Select(Mappers.ArtTypeModelMapper.Map) is IEnumerable<ArtTypeModel> retrievedATMs)
                {
                    return Ok(retrievedATMs);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // POST api/arttype
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ArtTypeModel artTypeModel) 
        {
            try
            {
                var complete = await Task.FromResult(_artTypeRespository.AddArtType(Mappers.ArtTypeModelMapper.Map(artTypeModel)));

                if (complete)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return BadRequest();
            }
        }

        // Using this to show what headers are allowed on this endpoint I believe
        // OPTIONS api/arttype
        [HttpOptions]
        [Authorize]
        public async Task<IActionResult> Options()
        {
            var headers = await Task.FromResult(HttpContext.Response.Headers);
            return Ok(headers);
        }
    }
}
