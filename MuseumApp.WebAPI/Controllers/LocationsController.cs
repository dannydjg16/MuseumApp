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

        // GET: api/locations/abc
        [HttpGet("abc")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetABC([FromQuery] string locationName = null)
        {
            var domain_locations = await Task.FromResult(_locationRepository.GetLocationsABC(locationName));

            if (domain_locations.Select(Mappers.LocationModelMapper.Map) is IEnumerable<LocationModel> locationModels)
            {
                return Ok(locationModels);
            }

            return NotFound();
        }

        // GET api/locations/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LocationModel>> Get([FromRoute] int id)
        {
            var location = await Task.FromResult(_locationRepository.GetLocationById(id));

            if (Mappers.LocationModelMapper.MapFullNoArtworks(location) is LocationModel locationModel)
            {
                return Ok(locationModel);
            }

            return NotFound();
        }

        // POST api/locations
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] LocationModel locationModel)
        {
            var domain_location = Mappers.LocationModelMapper.MapFullNoArtworks(locationModel);
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
            var edited = await Task.FromResult(_locationRepository.EditLocation(Mappers.LocationModelMapper.MapFullNoArtworks(locationModel)));

            if (edited)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
