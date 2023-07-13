using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationAPI.Interface;
using RegistrationAPI.Models;
using StackExchange.Redis;

namespace RegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistration _userRegistration;
        public UserRegistrationController(IUserRegistration userRegistration)
        {
            _userRegistration = userRegistration;
        }
       
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userRegistration.Add(user);
            return Ok("User Registered Successfully.");
        }


        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin(string userName, string password)
        {
            var userDetail = _userRegistration.Login(userName, password);
            if(userDetail == false)
            {
                return BadRequest("Invalid username or password.");
            }
            return Ok("User successfully logged in.");
        }

    }
}
