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
        private readonly IUsers users;

        public UsersController(IUsers users)
        {
            this.users = users;
        }

        [HttpGet]
        public List<FakeUser> Get()
        {
            return users.GetUsers();
        }
        [HttpGet]
        [Route("/user/{UserId}")]
        public FakeUser? Get(int UserId)
        {
            return users.GetUser(UserId);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            users.CreateUser(dto.Firstname, dto.Lastname, dto.Username, dto.Email, dto.Password);
            return Ok();
        }

        [HttpPost("/admin")]
        public IActionResult CreateAdmin([FromBody] CreateUserDto dto)
        {
            users.CreateUserAdmin(dto.Firstname, dto.Lastname, dto.Username, dto.Email, dto.Password);
            return Ok();
        }

        [HttpPut("update/username/user/{UserId}")]
        public IActionResult UpdateUsername(int UserId, [FromBody] UpdateUsernameDto dto)
        {
            users.ChangeUserName(UserId, dto.Username);
            return Ok();
        }
    }
}
