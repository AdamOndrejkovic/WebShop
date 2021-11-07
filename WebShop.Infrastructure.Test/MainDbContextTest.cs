using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using WebShop.Core;
using WebShop.DB;
using WebShop.DB.Enity;
using Xunit;

namespace WebShop.Infrastructure.Test
{
    public class MainDbContextTest
    {
        private readonly WebShopContext _mockedDbContext;

        public MainDbContextTest()
        {
            _mockedDbContext = Create.MockedDbContextFor<WebShopContext>();
        }
        
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            Assert.NotNull(_mockedDbContext);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeProduct()
        {
            Assert.True(_mockedDbContext.Products is DbSet<ProductEntity>);
        }
    }
}