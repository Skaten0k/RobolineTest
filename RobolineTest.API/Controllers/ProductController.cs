using Microsoft.AspNetCore.Mvc;
using RobolineTest.Domain.Core;
using Services.Interfaces;

namespace RobolineTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ICrudService<Product> _productService;
        private ILogger<ProductController> _logger;

        public ProductController(ICrudService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet]
        public async Task<Product> GetProduct(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Create(Product product)
        {
            await _productService.CreateAsync(product);
        }

        [HttpPut]
        public async Task Update(Product product)
        {
            await _productService.UpdateAsync(product);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _productService.DeleteAsync(id);
        }
    }
}
