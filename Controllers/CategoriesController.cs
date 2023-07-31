using FakeStore.Database.Models;
using FakeStoreApi.Models.Categories;
using FakeStoreApi.Models.Users;
using FakeStoreApi.Repository.FakeDb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategories categories;

        public CategoriesController(ICategories categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public List<FakeCategory> Get()
        {
            return categories.GetCategories();
        }
        [HttpGet("{CategoryId}")]
        public FakeCategory? Get(int CategoryId)
        {
            return categories.GetCategory(CategoryId);
        }

        [HttpPost("create/user")]
        public IActionResult CreateUser([FromBody] CreateCategoryDto dto)
        {
            categories.CreateCategory(dto.Name, dto.UserCreatorId);
            return Ok();
        }

        [HttpPut("update/name/category/{CategoryId}")]
        public IActionResult UpdateUsername(int CategoryId, [FromBody] UpdateCategoryNameDto dto)
        {
            categories.ChangeCategoryName(CategoryId, dto.Name);
            return Ok();
        }
    }
}
