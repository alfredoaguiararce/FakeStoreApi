using System.ComponentModel.DataAnnotations;

namespace FakeStoreApi.Models.Categories
{
    public class UpdateCategoryNameDto
    {
        [Required]
        public string Name { get; set; }
    }
}
