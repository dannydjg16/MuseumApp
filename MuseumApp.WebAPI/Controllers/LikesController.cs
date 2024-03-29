﻿using System;
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
    public class LikesController : ControllerBase
    {
        private readonly ILikesInterface _likesRepository;

        public LikesController(ILikesInterface likesRepository)
        {
            _likesRepository = likesRepository;
        }

        // GET api/likes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ArtworkModel>>> Get(int id)
        {
            try
            {
                var result = await Task.FromResult(_likesRepository.GetUsersLikes(id));

                if (result.Select(Mappers.ArtworkModelMapper.Map) is IEnumerable<ArtworkModel> artworkModels)
                {
                    return Ok(artworkModels);
                }

                return NotFound();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());

                return NotFound();
            }
        }

        // POST api/likes/artID/user/userID
        [HttpPost("{artID}/user/{userID}")]
        [Authorize]
        public async Task<IActionResult> Post(int artID, int userID)
        {
            try
            {
                var added = await Task.FromResult(_likesRepository.LikeArtwork(userID, artID));

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

        // DELETE api/likes/5
        [HttpDelete("{artID}/user/{userID}")]
        [Authorize]
        public async Task<IActionResult> Delete(int artID, int userID)
        {
            try
            {
                var deleted = await Task.FromResult(_likesRepository.UnlikeArtwork(userID, artID));

                if (deleted)
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
        // OPTIONS api/likes
        [HttpOptions]
        [Authorize]
        public async Task<IActionResult> Options()
        {
            var headers = await Task.FromResult(HttpContext.Response.Headers);
            return Ok(headers);
        }
    }
}
