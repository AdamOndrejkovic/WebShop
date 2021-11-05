using System.Collections.Generic;
using WebShop.Core;
using WebShop.Core.IServices;
using WebShop.Core.Models;
using WebShop.Domain.IRepository;

namespace WebShop.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public FilteredList GetProducts()
        {
            //return _productRepository.GetProducts();
            return null;
        }
    }
}