using LibraryApp.Data.Model;
using LibraryApp.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static System.Collections.Specialized.BitVector32;


namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _authService.Login(request);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid email or password" });
            }

            return Ok(user);
        }   
    }
    //[HttpPost("register")]
    //public async Task<ActionResult<Student>> Register(Student request)
    //{ 
    //   return Ok(student);
    //}

    //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
    //{
    //    using (var hmac = new HMACSHA512())
    //    {
    //        passwordSalt = hmac.Key;
    //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //    }

    //}

    //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    //{
    //    using (var hmac = new HMACSHA512(passwordSalt))
    //    {
    //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    //        return computedHash.SequenceEqual(passwordHash);
    //    }
    //}
}


