using Microsoft.AspNetCore.Mvc;
using RobolineTest.Domain.Core;
using Services.Interfaces;

namespace RobolineTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICrudService<ProductCategory> _categoryService;

        public CategoriesController(ICrudService<ProductCategory> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            return await _categoryService.GetAllAsync();
        }

        [HttpGet]
        public async Task<ProductCategory> GetCategory(int id)
        {
            return await _categoryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Create(ProductCategory category)
        {
            await _categoryService.CreateAsync(category);
        }

        [HttpPut]
        public async Task Update(ProductCategory category)
        {
            await _categoryService.UpdateAsync(category);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
        }
    }
}
