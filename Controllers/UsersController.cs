using FakeStore.Database.Models;
using FakeStoreApi.Models.Users;
using FakeStoreApi.Repository.FakeDb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUsers _Users;

        public UsersController(IUsers users)
        {
            _Users = users;
        }

        [HttpGet]
        public List<FakeUser> Get()
        {
            return _Users.GetUsers();
        }
        [HttpGet]
        [Route("/user/{UserId}")]
        public FakeUser? Get(int UserId)
        {
            return _Users.GetUser(UserId);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            _Users.CreateUser(dto.Firstname, dto.Lastname, dto.Username, dto.Email, dto.Password);
            return Ok();
        }

        [HttpPost("/admin")]
        public IActionResult CreateAdmin([FromBody] CreateUserDto dto)
        {
            _Users.CreateUserAdmin(dto.Firstname, dto.Lastname, dto.Username, dto.Email, dto.Password);
            return Ok();
        }

        [HttpPut("update/username/user/{UserId}")]
        public IActionResult UpdateUsername(int UserId, [FromBody] UpdateUsernameDto dto)
        {
            _Users.ChangeUserName(UserId, dto.Username);
            return Ok();
        }
    }
}
