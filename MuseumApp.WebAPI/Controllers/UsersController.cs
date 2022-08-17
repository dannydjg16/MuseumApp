using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuseumApp.Domain.Interfaces;
using MuseumApp.Domain.Models;
using MuseumApp.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System;

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

        // GET: api/users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get([FromQuery] string name = null)
        {
            try
            {
                var domainUsers = await Task.FromResult(_userRepository.GetUsers(name));

                if (domainUsers.Select(Mappers.UserModelMapper.Map) is IEnumerable<UserModel> userModels)
                {
                    return Ok(userModels);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetAsync(int id)
        {

            try
            {
                var d_user = await Task.FromResult(_userRepository.GetUserByID(id));

                if (Mappers.UserModelMapper.Map(d_user) is UserModel user)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }


        // GET api/users/email/5
        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<ActionResult<UserModel>> GetByEmailAsync(string email)
        {
            try
            {
                var d_user = await Task.FromResult(_userRepository.GetUserByEmail(email));

                if (Mappers.UserModelMapper.Map(d_user) is UserModel user)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // POST api/users
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            try
            {
                var created = await Task.FromResult(_userRepository.CreateAccount(Mappers.UserModelMapper.Map(user)));

                if (created)
                {
                    return CreatedAtAction(nameof(Get), new { id = user.ID }, user);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return BadRequest();
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UserModel user)
        {
            try
            {
                if (_userRepository.GetUserByID(user.ID) != null)
                {
                    var updated = await Task.FromResult(_userRepository.EditAccount(Mappers.UserModelMapper.Map(user)));

                    if (updated)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_userRepository.GetUserByID(id) != null)
                {
                    // deleted returns true if the deletion is successful
                    var deleted = await Task.FromResult(_userRepository.DeleteAccount(id));

                    if (deleted)
                    {
                        return NoContent();
                    }

                    return BadRequest();
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }
    }
}
