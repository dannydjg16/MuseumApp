using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumApp.Domain.Interfaces;
using MuseumApp.WebAPI.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MuseumApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _userRepository;

        public UsersController(IUserInterface userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetAsync(int id)
        {
            var d_user = await Task.FromResult(_userRepository.GetUserByID(id));
            if (Mappers.UserModelMapper.Map(d_user) is UserModel user)
            {
                return Ok(user);
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            var created = await Task.FromResult(_userRepository.CreateAccount(Mappers.UserModelMapper.Map(user)));
            if(created)
            {
                return CreatedAtAction(nameof(Get), new { id = user.ID}, user);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
