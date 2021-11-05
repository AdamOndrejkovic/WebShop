using System.Collections.Generic;
using System.Linq;
using WebShop.Core;
using WebShop.Domain.IRepository;

namespace WebShop.DB.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly WebShopContext _context;

        public ProductRepository(WebShopContext context)
        {
            _context = context;
        }
        
        public List<Product> GetProducts()
        {
            var selectQuery = _context.Products
                .Select(productEntity => new Product()
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                });

            return selectQuery.ToList();
        }
    }
}