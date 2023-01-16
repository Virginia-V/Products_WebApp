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

        public ProductsController(IProductService productService, 
            ILogger<ProductsController> logger) : base(logger)
        {
            _productService = productService;
        }

        [HttpGet]
        public Task<IActionResult> GetProductsAsync()
        {
            return HandleAsync(() => _productService.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetProductAsync(int id)
        {
            return HandleAsync(() => _productService.GetProductByIdAsync(id));
        }

        [HttpPost]
        public Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto productDto)
        {
            return HandleAsync(() => _productService.CreateProductAsync(productDto));
        }

    }
}
