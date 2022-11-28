using Microsoft.AspNetCore.Mvc;

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

        private List<Models.User> _users = new() {
            new Models.User() { Id= 1, Name = "Jon", Email = "jon.doe@email.com" },
            new Models.User() { Id= 2, Name = "Jane", Email = "jane.doe@email.com" }
        };

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
            var result = await Task.FromResult(_users);
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
            var result = await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Models.User user)
        {
            _users.Add(user);
            return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Models.User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser is null)
            {
                return NotFound();
            }

            // Update user here

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser is null)
            {
                return NotFound();
            }

            // Delete user here

            return NoContent();
        }
    }
}
