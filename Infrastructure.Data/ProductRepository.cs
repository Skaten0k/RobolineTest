using Microsoft.EntityFrameworkCore;
using RobolineTest.Domain.Core;
using RobolineTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobolineTest.Infrastructure.Data
{
    public class ProductRepository : IRepository<Product>
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            IQueryable<Product> products = _context.Product;
            return await products.Include(p=> p.Category).ToListAsync();
        }
        public async Task<Product> GetById(int id) 
        {
            IQueryable<Product> products = _context.Product;
            return await products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Product product) 
        {
                _context.ProductCategory.Attach(product.Category);
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
        }

        public async Task Update(Product product) 
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.ProductCategory.Attach(product.Category);
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id) 
        {
            var toDelete = await _context.Product.FindAsync(id);
            if (toDelete != null) 
            {
                _context.Remove(toDelete);
            }
            await _context.SaveChangesAsync();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
