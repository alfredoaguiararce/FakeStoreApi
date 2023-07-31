using FakeStoreApi.Repository.FakeDb.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProducts products;

        public ProductsController(IProducts products)
        {
            this.products = products;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products.GetProducts());
        }
    }
}
