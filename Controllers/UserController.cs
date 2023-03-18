using gerdisc.Core.Services;
using gerdisc.Data.DTOs;
using gerdisc.Propierties;
using gerdisc.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserOperation _userOperation;
        public UserController(IRepository repository, ISingingConfiguration singingConfig)
        {
            _userOperation = new UserOperation(repository, singingConfig);
        }
        [HttpPost]
        [Authorize(Roles = "Administrator, Professor")]
        public IActionResult CreateUser(UserDto user)
        {
            _userOperation.CreateUser(user);
            return Created("", user);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var response = _userOperation.Login(login);
            return Created("", response);
        }
    }
}