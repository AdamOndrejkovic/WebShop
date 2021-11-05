using System.Collections.Generic;
using WebShop.Core.Models;
using Xunit;

namespace WebShop.Core.Test.Models
{
    public class FilteredListTest
    {
        [Fact]
        public void FilteredList_Exists()
        {
            var filteredList = new FilteredList();
            Assert.NotNull(filteredList);
        }

        [Fact]
        public void FilteredList_HasPropertyList_OfTypeListOfProducts()
        {
            var expected = new List<Product>();
            {
                new Product() {Id = 1, Name = "Product1"};
            }
            ;
            var filteredList = new FilteredList();
            filteredList.List = expected;
            
            Assert.Equal(expected,filteredList.List);
        }
    }
}