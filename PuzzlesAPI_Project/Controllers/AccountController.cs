using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuzzlesAPI.Entities;
using PuzzlesAPI.Models;
using PuzzlesAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace PuzzlesAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
     

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
          
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] LoginUserDto dto)
        {
            string token = _accountService.CenerateJwt(dto);

            return Ok(token);
        }

        [HttpGet("allusers")]
        //[Authorize(Roles = "Admin")]
        public string Get()
        {
            return "All";
        }

    }
}
