using Microsoft.EntityFrameworkCore;
using RobolineTest.Domain.Core;
using RobolineTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobolineTest.Infrastructure.Data
{
    public class CategoryRepository : IRepository<ProductCategory>
    {
        private ProductContext _context;

        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            IQueryable<ProductCategory> categories = _context.ProductCategory;
            return await categories.ToListAsync();
        }
        public async Task<ProductCategory> GetById(int id)
        {
            return await _context.ProductCategory.FindAsync(id);
        }

        public async Task Create(ProductCategory category)
        {
            await _context.ProductCategory.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProductCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.ProductCategory.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var toDelete = await _context.ProductCategory.FindAsync(id);
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
