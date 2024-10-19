using Microsoft.EntityFrameworkCore;
using RobolineTest.Domain.Core;

namespace RobolineTest.Infrastructure.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public ProductContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Маппинг классов к таблицам БД, полей классов к столбцам соответствующих таблиц

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");

            modelBuilder.Entity<Product>().HasKey(p=> p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("Name").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnName("Description").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("Price").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();


            modelBuilder.Entity<ProductCategory>().HasKey(p=> p.Id);
            modelBuilder.Entity<ProductCategory>().Property(p=>p.Name).HasColumnName("Name").IsRequired();
            modelBuilder.Entity<ProductCategory>().Property(p => p.Description).HasColumnName("Description");
        }
    }
}
