using System.Collections.Generic;
using System.IO;
using Moq;
using WebShop.Core;
using WebShop.Core.IServices;
using WebShop.Core.Models;
using WebShop.Domain.IRepository;
using WebShop.Domain.Services;
using Xunit;

namespace WebShop.Domain.Test
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _mock;
        private readonly ProductService _service;

        public ProductServiceTest()
        {
            _mock = new Mock<IProductRepository>();
            _service = new ProductService(_mock.Object);
        }
        
        [Fact]
        public void ProductService_IsIProductService()
        {
            Assert.True(_service is IProductService);
        }

        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                (() => new ProductService(null))
            );
            
            Assert.Equal("Product repository can not be null", exception.Message);
        }

        [Fact]
        public void GetProducts_CallsProductRepositoriesFindAll_ExactlyOnce()
        {
            _service.GetProducts();
            _mock.Verify(r => r.GetProducts(), Times.Once);
        }

        [Fact]
        public void GetProducts_NoFilter_Returns_ListOfAllProducts()
        {
            var expected = new FilteredList();
            expected.List = new List<Product>()
            {
                new Product() { Id = 1, Name = "Lego" },
                new Product() { Id = 2, Name = "Lego2" },

            };
           
            
            _mock.Setup(r => r.GetProducts())
                .Returns(expected);
            var actual = _service.GetProducts();
            Assert.Equal(expected, actual);
        }
    }
}