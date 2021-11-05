using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core;
using WebShop.Core.IServices;
using WebShop.WebApi.Dtos.Product;

namespace WebShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public ActionResult<FilteredListDto> GetAll()
        {
            var filteredList = new FilteredListDto();
            filteredList.List = new List<ProductDto>()
            {
                new ProductDto(){Id =1, Name = "Bricks"},
                new ProductDto(){Id =2, Name = "Jelly"},
                new ProductDto(){Id =3, Name = "Hamburger"},
            };
            return filteredList;
        }
    }
}