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
    public class LocationTypeController : ControllerBase
    {
        private readonly ILocationTypeInterface _locationTypeRepository;

        public LocationTypeController(ILocationTypeInterface locationTypeRepository)
        {
            _locationTypeRepository = locationTypeRepository;
        }

        // GET: api/locationtype
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LocationTypeModel>>> Get()
        {
            try
            {
                var domainLTs = await Task.FromResult(_locationTypeRepository.GetLocationTypes());

                if (domainLTs.Select(Mappers.LocationTypeModelMapper.Map) is IEnumerable<LocationTypeModel> locationTypeModels)
                {
                    return Ok(locationTypeModels);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // GET: api/locationtype/abc
        [HttpGet("abc")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LocationTypeModel>>> GetABC()
        {
            try
            {
                var domainLTs = await Task.FromResult(_locationTypeRepository.GetLocationTypesABC());

                if (domainLTs.Select(Mappers.LocationTypeModelMapper.Map) is IEnumerable<LocationTypeModel> locationTypeModels)
                {
                    return Ok(locationTypeModels);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // POST api/locationtype
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LocationTypeModel locationTypeModel)
        {
            try
            {
                var domainLT = Mappers.LocationTypeModelMapper.Map(locationTypeModel);

                var added = await Task.FromResult(_locationTypeRepository.AddLocationType(domainLT));

                if (added)
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
        // OPTIONS api/locationtype
        [HttpOptions]
        [Authorize]
        public async Task<IActionResult> Options()
        {
            var headers = await Task.FromResult(HttpContext.Response.Headers);
            return Ok(headers);
        }
    }
}
