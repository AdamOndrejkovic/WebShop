using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core;
using WebShop.Core.IServices;

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
        public ActionResult<IEnumerable<Product>> GetOwners()
        {
            var products = _productService.GetOwners();
            if (products != null)
            {
                //Ask about
                return new ActionResult<IEnumerable<Product>>(products);
            }

            return BadRequest("No owners were found");
        }
    }
}