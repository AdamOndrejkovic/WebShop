using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebShop.Core;
using WebShop.Core.Models;
using WebShop.Domain.IRepository;

namespace WebShop.DB.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly WebShopContext _context;

        public ProductRepository(WebShopContext context)
        {
            _context = context ?? throw new InvalidDataException("Product Repository must have a DBContext in constructor");
        }
        
        public FilteredList GetProducts()
        {
            var selectQuery = _context.Products
                .Select(productEntity => new Product()
                {
                    Id = productEntity.Id,
                    Name = productEntity.Name,
                });

            var filteredList = new FilteredList();
            filteredList.List = selectQuery.ToList();
            return filteredList;
        }
    }
}