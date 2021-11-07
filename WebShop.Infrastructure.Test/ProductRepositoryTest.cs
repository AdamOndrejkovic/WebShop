using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using WebShop.Core;
using WebShop.Core.Models;
using WebShop.DB;
using WebShop.DB.Enity;
using WebShop.DB.Repositories;
using WebShop.Domain.IRepository;
using Xunit;

namespace WebShop.Infrastructure.Test
{
    public class ProductRepositoryTest
    {
        public ProductRepositoryTest()
        {
        }
        
        [Fact]
        public void ProductRepository_IsIProductRepository()
        {
            var fakeContext = Create.MockedDbContextFor<WebShopContext>();
            var repository = new ProductRepository(fakeContext);
            Assert.IsAssignableFrom<IProductRepository>(repository);
        }
        
        [Fact]
        public void ProductRepository_WithNullProductRepository_ThrowsInvalidDataException()
        {
            var actual = Assert.Throws<InvalidDataException>(
                (() => new ProductRepository(null)));
            Assert.Equal("Product Repository must have a DBContext in constructor", actual.Message);
        }

        [Fact]
        public void FindAll_GetAllProductsEntitiesInDBContext_AsAListOfProducts()
        {
            var fakeContext = Create.MockedDbContextFor<WebShopContext>();
            var repository = new ProductRepository(fakeContext);
            var list = new List<ProductEntity>
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 200.00
                },
                new ProductEntity()
                {
                    Id = 2,
                    Name = "Usb",
                    Price = 20.00
                },
                new ProductEntity()
                {
                    Id = 3,
                    Name = "IWatch",
                    Price = 450.00
                }
            };
            
            fakeContext.Set<ProductEntity>().AddRange(list);
            fakeContext.SaveChanges();
            
            var repositoryList = list.Select(pe => new Product()
            {
                Id = pe.Id,
                Name = pe.Name
            }).ToList();
            
            var expectedList = new FilteredList();
            expectedList.List = repositoryList;

            var actualResult = repository.GetProducts();
            Assert.Equal(expectedList.List, actualResult.List, new Comparer());
        }
    }
    
    public class Comparer: IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name && x.Price.Equals(y.Price);
        }

        public int GetHashCode(Product obj)
        {
            return HashCode.Combine(obj.Id, obj.Name, obj.Price);
        }
    }
}