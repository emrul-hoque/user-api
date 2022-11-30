using Microsoft.AspNetCore.Mvc;
using My.User.Api.Services;

namespace My.User.Api.Controllers
{

    /*
     * http://localhost:{PORT}/api/users/1
     * 
     * Base URL: http://localhost:{PORT}
     * Path: /api/users
     * Path/Route Param: 1
     */

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get all users
        /// Path: /api/users/
        /// </summary>
        /// <returns>A collection of user</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await Task.FromResult(UserService.GetAll());

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Get a user by id
        /// Path: /api/users/1
        /// </summary>
        /// <param name="id">The user id</param>
        /// <returns>A user</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await Task.FromResult(UserService.GetById(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Models.User newUser)
        {
            UserService.Add(newUser);
            return CreatedAtAction(nameof(Create), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest();
            }

            var existingUser = UserService.GetById(updatedUser.Id);

            if (existingUser is null)
            {
                return NotFound();
            }

            UserService.Update(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = UserService.GetById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            // Delete user here
            UserService.Delete(id);

            return NoContent();
        }
    }
}
