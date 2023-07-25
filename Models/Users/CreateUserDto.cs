using System.ComponentModel.DataAnnotations;

namespace FakeStoreApi.Models.Users
{
    public class CreateUserDto
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
