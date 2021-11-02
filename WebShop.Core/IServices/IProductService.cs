using System.Collections.Generic;

namespace WebShop.Core.IServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetOwners();
    }
}