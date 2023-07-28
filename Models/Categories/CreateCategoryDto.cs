using System.ComponentModel.DataAnnotations;

namespace FakeStoreApi.Models.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserCreatorId { get; set; }
    }
}
