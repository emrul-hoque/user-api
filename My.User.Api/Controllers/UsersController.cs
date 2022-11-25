using Microsoft.AspNetCore.Mvc;

namespace My.User.Api.Controllers
{
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
    }
}
