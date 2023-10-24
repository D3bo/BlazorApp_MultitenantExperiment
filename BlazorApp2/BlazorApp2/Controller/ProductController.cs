using BlazorApp2.Data;
using BlazorApp2.Services;
using BlazorApp2.Shared.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productServices.GetProductsAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var result = await _productServices.AddProduct(product);
            return Ok(result);
        }
    }
}
