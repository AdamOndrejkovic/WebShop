using System.Collections.Generic;
using WebShop.Core;

namespace WebShop.Domain.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}