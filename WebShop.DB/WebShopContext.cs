using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebShop.DB.Enity;

namespace WebShop.DB
{
    public class WebShopContext: DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = new ProductEntity()
            {
                Id = 1,
                Name = "Laptop",
                Price = 200.00
            };
            
            var productTwo = new ProductEntity()
            {
                Id = 2,
                Name = "Usb",
                Price = 20.00
            };
            
            var productThree = new ProductEntity()
            {
                Id = 3,
                Name = "IWatch",
                Price = 450.00
            };

            List<ProductEntity> productEntities = new List<ProductEntity>();
            productEntities.Add(product);
            productEntities.Add(productTwo);
            productEntities.Add(productThree);

            foreach (var vaProductEntity in productEntities)
            {
                modelBuilder.Entity<ProductEntity>()
                    .HasData(vaProductEntity);
            }
        }
        
        public virtual DbSet<ProductEntity> Products { get; set; }
    }
}