using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibraryApp.Data.Dto;
using LibraryApp.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService; 
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userService.GetUsers();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto user)
        {
            var userAdd = await _userService.AddUser(user);

            return Ok(userAdd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, User user)
        {
            var userUpdate = await _userService.UpdateUser(id, user);
            return Ok(userUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);

            return Ok(user);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchString)
        {
            var users = await _userService.Search(searchString);

            return Ok(users);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var emailReset = await _userService.ForgotPassword(email);

            return Ok(emailReset);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPassword request)
        {
            var emailReset = await _userService.ResetPassword(request);

            return Ok(emailReset);
        }
    }
}
