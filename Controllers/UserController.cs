using ApiDemo.Models;
using ApiDemo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController>? _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUsers")]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            try
            {
                var users = _userService.GetAllUsers();
                var userDtos = _mapper.Map<List<UserDto>>(users); // Converte User para UserDto
                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error fetching users");
                return StatusCode(500, "An error occurred while fetching users");
            }
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserDto> GetById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                var userDto = _mapper.Map<UserDto>(user); // Converte User para UserDto
                return Ok(userDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error fetching user by ID");
                return StatusCode(500, "An error occurred while fetching user by ID");
            }
        }

        [HttpPost(Name = "CreateUser")]
        public ActionResult CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null)
                {
                    return BadRequest("User data is required.");
                }

                var user = _mapper.Map<User>(userDto); // Converte UserDto para User
                _userService.CreateUser(user);
                var createdUserDto = _mapper.Map<UserDto>(user);

                return CreatedAtAction(nameof(GetById), new { id = createdUserDto.Id }, createdUserDto);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error creating user");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public ActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            try
            {
                if (userDto == null || id != userDto.Id)
                {
                    return BadRequest("Invalid user data.");
                }

                var user = _mapper.Map<User>(userDto); // Converte UserDto para User
                _userService.UpdateUser(user);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating user");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error deleting user");
                return BadRequest(ex.Message);
            }
        }
    }
}
