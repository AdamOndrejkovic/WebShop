using Xunit;

namespace WebShop.Core.Test.Models
{
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product();
        }
        
        [Fact]
        public void ProductClass_Exists()
        {
            Assert.NotNull(_product);
        }

        [Fact]
        public void ProductClass_HasId_WithTypeInt()
        {
            int expected = 1;
            _product.Id = 1;
            Assert.Equal(expected,_product.Id);
            Assert.True(_product.Id is int);
        }

        [Fact]
        public void ProductClass_HasName_WithTypeInt()
        {
            string expected = "Bob";
            _product.Name = "Bob";
            
            Assert.Equal(expected, _product.Name);
            Assert.True(_product.Name is string);
        }

        [Fact]
        public void Equals_WithProductWithSameProperties_ReturnTrue()
        {
            var product1 = new Product() {Id = 1, Name = "Mark"};
            var product2 = new Product() {Id = 1, Name = "Mark"};
            Assert.True(product1.Equals(product2));
            Assert.True(product2.Equals(product1));
            Assert.False(product1.Equals(null));
            Assert.False(product2.Equals(null));
        }
    }
}