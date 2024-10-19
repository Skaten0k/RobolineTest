using RobolineTest.Domain.Core;
using RobolineTest.Domain.Interfaces;
using RobolineTest.Infrastructure.Data;
using Services.Interfaces;

namespace RobolineTestSevices
{
    public class CategoryService : ICrudService<ProductCategory>
    {
        private readonly IRepository<ProductCategory> _repository;

        public CategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task CreateAsync(ProductCategory category)
        {
            Validate(category);
            await _repository.Create(category);
        }

        public async Task UpdateAsync(ProductCategory category)
        {
            Validate(category);
            await _repository.Update(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Delete(id);
        }


        //Валидация
        private void Validate(ProductCategory toValidate)
        {
            if (toValidate.Name.Trim().Length == 0)
            {
                throw new Exception("Название обязательно");
            }
        }
    }
}
