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
    public class LocationsController : ControllerBase
    {
        private readonly ILocationInterface _locationRepository;

        public LocationsController(ILocationInterface locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: api/locations
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LocationModel>>> Get([FromQuery] string locationName = null)
        {
            var domain_locations = await Task.FromResult(_locationRepository.GetLocations(locationName));

            if (domain_locations.Select(Mappers.LocationModelMapper.Map) is IEnumerable<LocationModel> locationModels)
            {
                return Ok(locationModels);
            }

            return NotFound();
        }

        // GET api/locations/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LocationModel>> Get([FromRoute] int locationId)
        {
            var location = await Task.FromResult(_locationRepository.GetLocationById(locationId));

            if (Mappers.LocationModelMapper.Map(location) is LocationModel locationModel)
            {
                return Ok();
            }

            return NotFound();
        }

        // POST api/locations
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LocationModel locationModel)
        {
            var domain_location = Mappers.LocationModelMapper.Map(locationModel);
            var added = await Task.FromResult(_locationRepository.AddLocation(domain_location));

            if (added)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/locations/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] LocationModel locationModel)
        {
            var edited = await Task.FromResult(_locationRepository.EditLocation(Mappers.LocationModelMapper.Map(locationModel)));

            if (edited)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
