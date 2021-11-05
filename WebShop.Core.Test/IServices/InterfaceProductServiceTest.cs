using System.Collections.Generic;
using Moq;
using WebShop.Core.IServices;
using WebShop.Core.Models;
using Xunit;

namespace WebShop.Core.Test.IServices
{
    public class InterfaceProductServiceTest
    {
        [Fact]
        public void IProductService_Exists()
        {
            var serviceMock = new Mock<IProductService>();
            Assert.NotNull(serviceMock.Object);
        }

        [Fact]
        public void GetAll_WithNoParams_ReturnsFilteredList()
        {
            var expectedResult = new FilteredList()
            {
                List = new List<Product>()
                {
                    new Product() {Id = 1, Name = "Bricks"},
                    new Product() {Id = 2, Name = "Pizza"},
                }
            };
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(ps => ps.GetProducts())
                .Returns(expectedResult);
            
            Assert.Equal(expectedResult,serviceMock.Object.GetProducts());
        }
    }
}