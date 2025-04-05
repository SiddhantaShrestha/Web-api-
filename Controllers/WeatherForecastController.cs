using Microsoft.AspNetCore.Mvc;
using web_api.DTO;
using web_api.Service;
using System.Collections.Generic;
using System.Linq;
using System;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IUserService userService, ILogger<WeatherForecastController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();
        }

        [HttpGet("name")]
        public string GetName()
        {
            return "Doja";
        }

        [HttpPut("put")]
        public string PutName()
        {
            return "Putting";
        }

        private static string value = string.Empty;

        [HttpPost("concat-string")]
        public string ConcatString([FromQuery] string a, [FromQuery] string b)
        {
            value = a + b;
            return value;
        }

        [HttpDelete("delete")]
        public string DeleteName([FromQuery] string a, [FromQuery] string b)
        {
            value = value.Replace(a, "").Replace(b, "");
            return value;
        }

        [HttpGet("get-value")]
        public string GetValue()
        {
            return value;
        }

        // ---------------- User Management APIs ---------------- 

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserRegisterDTO user)
        {
            if (_userService.FindUser(user.Email) != null)

            {
                return Conflict("User already exists");
            }

            var result = _userService.AddUser(user);
            if (result)
            {
                return StatusCode(201, "User Registered Successfully");
            }
            else
            {
                return BadRequest("Failed to register user");
            }
        }

        [HttpDelete("RemoveUser")]
        public IActionResult RemoveUser([FromQuery] string email)
        {
            if (_userService.FindUser(email) == null)
            {
                return NotFound("User not found");
            }

            var result = _userService.DeleteUser(email);
            if (result)
            {
                return Ok("User Deleted Successfully");
            }
            else
            {
                return BadRequest("Failed to delete user");
            }
        }

        [HttpPut("UpdateUser/{email}")]
        public IActionResult UpdateUser(string email, [FromBody] UserRegisterDTO updatedUser)
        {
            if (_userService.FindUser(email) == null)
            {
                return NotFound("User not found");
            }

            var result = _userService.UpdateUser(email, updatedUser);
            if (result)
            {
                return Ok("User Updated Successfully");
            }
            else
            {
                return BadRequest("Failed to update user");
            }
        }

    }
}