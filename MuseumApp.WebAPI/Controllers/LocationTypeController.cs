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
            var domainLTs = await Task.FromResult(_locationTypeRepository.GetLocationTypes());

            if (domainLTs.Select(Mappers.LocationTypeModelMapper.Map) is IEnumerable<LocationTypeModel> locationTypeModels)
            {
                return Ok(locationTypeModels);
            }

            return NotFound();
        }

        // POST api/locationtype
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LocationTypeModel locationTypeModel)
        {
            var domainLT = Mappers.LocationTypeModelMapper.Map(locationTypeModel);
            var added = await Task.FromResult(_locationTypeRepository.AddLocationType(domainLT));

            if (added)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
