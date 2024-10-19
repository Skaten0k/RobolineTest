using RobolineTest.Domain.Core;
using RobolineTest.Domain.Interfaces;
using RobolineTest.Infrastructure.Data;
using Services.Interfaces;
using System.Linq.Expressions;

namespace RobolineTestSevices
{
    public class ProductService : ICrudService<Product>
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task CreateAsync(Product product)
        {
                Validate(product);
                await _repository.Create(product);
        }

        public async Task UpdateAsync(Product product)
        {
            Validate(product);
            await _repository.Update(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.Delete(id);
        }


        //Валидация
        private void Validate(Product toValidate) 
        {
            if(toValidate.Price <= 0)
            {
                throw new Exception("Цена не может быть меньше или равна 0");
            }
            if (toValidate.Name.Trim().Length == 0) 
            { 
                throw new Exception("Название обязательно"); 
            }
            if(toValidate.Description.Trim().Length == 0)
            {
                throw new Exception("Описание обязательно");
            }
            if(toValidate.Category == null)
            {
                throw new Exception("Необходимо отнести товар к категории");
            }
        }
    }
}
