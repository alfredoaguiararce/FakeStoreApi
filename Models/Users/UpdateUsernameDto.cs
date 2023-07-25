using System.ComponentModel.DataAnnotations;

namespace FakeStoreApi.Models.Users
{
    public class UpdateUsernameDto
    {
        [Required]
        public string Username { get; set; }
    }
}
