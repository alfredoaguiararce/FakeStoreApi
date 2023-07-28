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
        private readonly ICategories _Categories;

        public CategoriesController(ICategories categories)
        {
            _Categories = categories;
        }

        [HttpGet]
        public List<FakeCategory> Get()
        {
            return _Categories.GetCategories();
        }
        [HttpGet("{CategoryId}")]
        public FakeCategory? Get(int CategoryId)
        {
            return _Categories.GetCategory(CategoryId);
        }

        [HttpPost("create/user")]
        public IActionResult CreateUser([FromBody] CreateCategoryDto dto)
        {
            _Categories.CreateCategory(dto.Name, dto.UserCreatorId);
            return Ok();
        }

        [HttpPut("update/name/category/{CategoryId}")]
        public IActionResult UpdateUsername(int CategoryId, [FromBody] UpdateCategoryNameDto dto)
        {
            _Categories.ChangeCategoryName(CategoryId, dto.Name);
            return Ok();
        }
    }
}
