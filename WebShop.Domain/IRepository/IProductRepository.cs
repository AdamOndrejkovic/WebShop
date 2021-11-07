using System.Collections.Generic;
using WebShop.Core;
using WebShop.Core.Models;

namespace WebShop.Domain.IRepository
{
    public interface IProductRepository
    {
        FilteredList GetProducts();
    }
}