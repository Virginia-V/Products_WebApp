using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Bll.Interfaces;
using Products.Common.Dtos.Products;

namespace Products.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : AppBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProductAsync(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task CreateProductAsync([FromBody] CreateProductDto productDto)
        {
            await _productService.CreateProductAsync(productDto);
        }   
    }
}
